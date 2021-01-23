    public class WorkingController : Controller
        {
            // GET: Working
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public JsonResult Save([FromBody]WorkingModel model)
            {
                // All model properties are null here????
    
                return Json("Success");
            }
        }
