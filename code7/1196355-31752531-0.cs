    /// <summary>
    /// Custom authorization attribute for use on controllers and actions. 
    /// Throws an exception if the user is not authorized.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ActionPermissionAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Override OnAuthorization, not AuthorizeCore as AuthorizeCore will force user login prompt rather than inform the user of the issue.
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var user = HttpContext.Current.Request.LogonUserIdentity;
            // Check user can use the app or the specific controller/action
            var authorised = ...
            if (!authorised)
                throw new UnauthorizedAccessException("You are not authorised to perform this action.");
            base.OnAuthorization(filterContext);
        }
    }
