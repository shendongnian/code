    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome(FormCollection form)
        {
            ViewBag.Name = form["SearchString"];
            return View();
        } 
    }
