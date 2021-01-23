    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }
    
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }
    }
    
    
    public class ReportController : Controller
    {
        public ActionResult Index(string Id)
        {
            return null;
        }
    }
