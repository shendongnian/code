    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            var model = new DropDownModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(DropDownModel model)
        {
            // Get the selected value
            return View();
        }
    }
