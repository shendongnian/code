    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Define your UserName
            Session["Username"] = "Admin User";
            return View();
        }
    }
