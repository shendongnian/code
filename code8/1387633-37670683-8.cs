    public class AuthorizeWithLoggingAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new LoggingActionResult(new HttpUnauthorizedResult(), filterContext);
        }
    }
    public class LoggingActionResult : ActionResult
    {
        private readonly ActionResult innerActionResult;
        private readonly AuthorizationContext filterContext;
        public LoggingActionResult(ActionResult innerActionResult, AuthorizationContext filterContext)
        {
            if (innerActionResult == null)
                throw new ArgumentNullException("innerActionResult");
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            this.innerActionResult = innerActionResult;
            this.filterContext = filterContext;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            // Do logging (or apparently you want auditing) here
            Log(this.filterContext);
            innerActionResult.ExecuteResult(context);
        }
    }
