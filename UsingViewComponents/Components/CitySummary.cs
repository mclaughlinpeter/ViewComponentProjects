using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            string target = RouteData.Values["id"] as string;
            var cities = repository.Cities.Where(city => target == null || string.Compare(city.Country, target, true) == 0);
            return View(new CityViewModel {
                Cities = cities.Count(), Population = cities.Sum(c => c.Population)
            });
        }
    }
}