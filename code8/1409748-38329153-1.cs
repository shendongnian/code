    public class ErrorsController : Controller
    {
        public ActionResult General(Exception exception)
        {
            return Content("General failure", "text/plain");
        }
    
        public ActionResult Http404()
        {
            return Content("Not found", "text/plain");
        }
    
        public ActionResult Http403()
        {
            return Content("Forbidden", "text/plain");
        }
    }
