    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }
    
            var rd = httpContext.Request.RequestContext.RouteData;
            string id = rd.Values["id"] as string;
            if (string.IsNullOrEmpty(id))
            {
                // No id was specified => we do not allow access
                return false;
            }
    
            string roles = ItemAccess.AuthorizedRoleList(AccessType.Write, id);
            return httpContext.User.IsInRole(roles))
        }
    }
