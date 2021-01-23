    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Name = User.Identity.Name ?? "Anonymouse user";
            base.OnActionExecuting(filterContext);
        }
    }
