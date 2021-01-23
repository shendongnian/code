    [CustomAuthentication]//<-- If you put it here, it applies to the whole controller
    public class HomeController : Controller
    {
        [CustomAuthentication]//<-- Here it only applies to the Index action
        public ActionResult Index()
        {
            return View();
        }
    }
