    [RoutePrefix("")]
    public class HomeController : Controller
    {
        Route("{state?}/{city?}/{id?}")
        public ActionResult Index(string state, string city, int id)
        {
            //your codes
            return View();
        }
    }
