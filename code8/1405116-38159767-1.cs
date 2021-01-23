    public class SiteUserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SiteUserViewModel();
            //Replace this with logic that reads cities from the database
            var city1 = new SelectListItem { Text = "Johannesburg", Value = "1" };
            var city2 = new SelectListItem { Text = "Cape Town", Value = "2" };
            model.Cities = new List<SelectListItem> { city1, city2 };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateUser(SiteUser user)
        {
            System.Diagnostics.Debugger.Break();
            //Write the code to add user to the database
            return View();
        }
    }
