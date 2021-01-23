    public class AuthorizeSessionAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var customerId = httpContext.Session["CustomerId"];
            if (customerId == null)
            {
                var lo = httpContext.GetOwinContext().Authentication;
                lo.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
 
                return false;
            }
            return true;
        }
    }
