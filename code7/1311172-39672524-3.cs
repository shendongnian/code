    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var lib = new MyLib.MyClass();
            var msg = lib.GetUserAgent(System.Web.HttpContext.Current);
            lib.WriteToResponse(System.Web.HttpContext.Current, "user agent is: " + msg);
            return new HttpStatusCodeResult(200);
        }
    }
