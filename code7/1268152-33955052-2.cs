    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IPrincipal principal = ((BaseApiController)actionContext.ControllerContext.Controller).User;
            //is the user already logged in on the system. This would work perfectly if you have a cookie in your web application authorizing the user
            bool isAuthenticated = principal != null && principal.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                // Deny request or you could also check the request headers for an authorization token
                return false;
            }
            // Save UserID to be used later in your controllers
            ((BaseApiController)actionContext.ControllerContext.Controller).UserID = UserID;
    
            // Authorize user, or you could also check if the user has the correct roles 
            return true;
        }
    }
