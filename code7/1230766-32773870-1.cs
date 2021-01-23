    public class AuditFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var userName = HttpContext.Current.User.Identity.Name;
            var time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionContext.ActionDescriptor.ActionName
            Logger.Log(string.Format("user: {0}, date: {1}, controller {2}, action {3}", userName, time, controllerName, actionName));
        }
    }
