    public class HolidayController : ApiController
    {
        [AllowAnonymous]    
        public ActionResult YourMethod()
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
