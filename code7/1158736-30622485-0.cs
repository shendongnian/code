    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ActionPermissionAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Override OnAuthorization, not AuthorizeCore as AuthorizeCore will force user login prompt rather than inform the user of the issue.
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
           
            bool authorised = ... // Check permissions here
            if (!authorised)
                throw new UnauthorizedAccessException("You are not authorised to perform this action.");
            base.OnAuthorization(filterContext);
        }
    }
