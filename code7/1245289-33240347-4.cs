    public class CAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
                return false;
            IIdentity user = httpContext.User.Identity;
            CPrincipal cPrincipal = new CPrincipal(user);
            httpContext.User = cPrincipal;
            return true;
        } 
    }
