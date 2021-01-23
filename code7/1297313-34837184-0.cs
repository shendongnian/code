    namespace SampleWebApplication.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                string link = Url.Action("Profile", "Account");
                return View();
            }
        }
    }
