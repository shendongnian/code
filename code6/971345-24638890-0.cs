    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Title = "Hello world";
        }
    }
    public class SharedController : BaseController
    {
        ...
    }
