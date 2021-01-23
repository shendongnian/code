    public class ErrorsController : Controller
    {
        /// <summary> GET: /Errors/NotFound </summary>
        public ActionResult NotFound()
        {
            object model = Request.Url.PathAndQuery;
            if (!Request.IsAjaxRequest()) {
                return View(model);
            } else {
                return PartialView("_NotFound", model);
            }
        }
    }
