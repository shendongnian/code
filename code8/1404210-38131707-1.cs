    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["Errors"] = new List<ErrorViewModel>
            {
                new ErrorViewModel { ErrorDescription = "Not enough cowbell" },
                new ErrorViewModel { ErrorDescription = "Too much cowbell" }
            };
            return RedirectToAction("Error");
        }
        [SetErrorModel]
        public ActionResult Error()
        {
            return View("Index", new MyViewModel { Name = "Cowbell" });
        }
    }
