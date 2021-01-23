    public class ChoicePeriodController : Controller
    {
        public ActionResult Index(typeControl) 
        {
             // Put your logic here
             return View();
        }
        public ActionResult TypeControl(typeControl)
        {
            return Index(typeControl);
        }
    }
