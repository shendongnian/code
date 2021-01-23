    public sealed class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            ActionResult result;
    
            object model = Request.Url.PathAndQuery;
    
            if (!Request.IsAjaxRequest())
                result = View(model);
            else
             return RedirectToAction("Index", "HomeController");
        }
    }
