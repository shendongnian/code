    public class CustomAuthorizeFilter: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false; //User not Authorized
            }
            else
            {
                 //Check your conditions here
            }
         }
    } 
