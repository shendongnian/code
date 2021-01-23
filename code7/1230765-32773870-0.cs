    public class AuditFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            var time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            Logger.Log(string.Format("user: {0}, date: {1}, controller {2}, action {3}", userName, time, controllerName, actionName));
        }
    }
