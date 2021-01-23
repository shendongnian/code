    public class MyCountry
    {
        public int CountryCode { get; set; }
        public string Country { get; set; }
    }
    public class Region
    {
        public int CountryCode { get; set; }
        public string RegionName { get; set; }
    }
    public class ViewModel
    {
        public List<MyCountry> Country { get; set; }
        public List<Region> Region { get; set; }
    }
    public class DropDownExampleController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModel();
            var c1 = new MyCountry { Country = "South Africa", CountryCode = 1 };
            var c2 = new MyCountry { Country = "Russia", CountryCode = 2 };
            model.Country = new List<MyCountry> { c1, c2 };
            var r1 = new Region { RegionName = "Gauteng", CountryCode = 1};
            var r2 = new Region { RegionName = "Western Cape", CountryCode = 1 };
            var r3 = new Region { RegionName = "Siberia", CountryCode = 2 };
            model.Region = new List<Region> { r1, r2,r3};
            return View(model);
        }
        [HttpPost]
        public JsonResult GetRegionsByCountryCode(string countryCode)
        {
            var r1 = new Region { RegionName = "Gauteng", CountryCode = 1 };
            var r2 = new Region { RegionName = "Western Cape", CountryCode = 1 };
            var r3 = new Region { RegionName = "Siberia", CountryCode = 2 };
            var regions = new List<Region> { r1, r2, r3 };
            var results = regions.Where(r => r.CountryCode == Int32.Parse(countryCode)).ToList();
            return Json(results);
        }
    }
