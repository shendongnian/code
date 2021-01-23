    public class WorkingController : Controller
    {
        // GET: Working
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Save(WorkingModel model)
        {
            // All model properties are null here????
            return Json("Success");
        }
    }
