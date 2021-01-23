    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View("~/Views/Homees/index.cshtml");
            }
            public ActionResult Contact()
            {
                return View();
            }
        }
