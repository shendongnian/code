    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Checkbox model)
        {
            // work with model.IsChecked
        }
    }
