    public class HomeController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Index(Person p)
        {
            //Just for the sake of this example.
            return Json(p);
        }
    }
