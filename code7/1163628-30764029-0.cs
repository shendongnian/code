    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Accounts = new AccountsViewModel();
            ViewBag.HomePage = new HomePageViewModel();
 
            return View();
        }
    }
