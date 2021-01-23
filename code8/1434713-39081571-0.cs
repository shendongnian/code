    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = new GetData().GetBasic();
            return View(data);
        }
    
    }
