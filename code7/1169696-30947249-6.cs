    [Authorize(Roles = "Admin, Editor")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [BlackList(Roles = "Editor")]
        public ActionResult About()
        {
            return View();
        }
    }
