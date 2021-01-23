    public class HandleExceptionsAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.Exception.InsertIntoDB(Membership.CurrentUserId, filterContext.RouteData.Values["controller"].ToString(), filterContext.RouteData.Values["action"].ToString());
        }
    }
    [HandleExceptionsAttribute(View = "/Error/Index")]
    public class BaseController : Controller
    {
        // Code...
    }
