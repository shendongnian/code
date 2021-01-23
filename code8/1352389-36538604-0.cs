    public class CheckLoggedInAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext) 
        {
            //Authorization logic Here. You can access the session using httpContext. Return false if your authorization fails
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Logic when authorization fails, modify the ViewResult or something.
            base.HandleUnauthorizedRequest(filterConext)
        }
    }
