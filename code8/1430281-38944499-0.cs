    public class AuditLoggingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do something
            base.OnActionExecuting(filterContext);
        }    
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           // Do something
        }
    }
