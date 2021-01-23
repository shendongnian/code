    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthoriseActionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var user = HttpContext.Current.Request.LogonUserIdentity;
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            // call existing authorisation function here
            // using user, controller, action to determine if user has access
            bool authorised = ...
            if (!authorised) {
                // throw exception or redirect
                throw new UnauthorizedAccessException("You are not authorised to perform this action.");
            }
            base.OnAuthorization(filterContext);            
        }
    }
