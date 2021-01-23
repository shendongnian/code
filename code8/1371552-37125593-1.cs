    public class HomeController : Controller
    {
        //***here is where it's applied. you can also do this globally in Global.asax if preferred***
        [CustomAuthentication]
        public ActionResult Index()
        {
            return View();
        }
    }
