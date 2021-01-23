    public class HomeController : Controller
    {
        [CustomAuthorize(FirstNames = "Aydin")]
        public ActionResult Index()
        {
            return View();
        }
    }
