    namespace arrgg.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult DoSomething()
            {
                // Or whatever you require here...
                return View();
            }
        }
    }
