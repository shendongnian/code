    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
    
            return View();
        }
    
        public ActionResult TestError() // id = error code 
        {
            return new HttpStatusCodeResult(301, "Your custom error text");
        }
    }
