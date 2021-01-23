    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
            var rd = httpContext.Request.RequestContext.RouteData;
            // Get the id of the requested resource from the route data
            string resourceId = rd.Values["id"] as string;
            if (string.IsNullOrEmpty(resourceId))
            {
                // No id of resource was specified => we do not allow access
                return false;
            }
    
            string userId = httpContext.User.Identity.GetUserId();
            return IsAccessibleByUser(resourceId, userId);
        }
    
        private bool IsAccessibleByUser(string resourceId, string userId)
        {
            // You know what to do here => fetch the requested resource 
            // from your data store and verify that the current user is
            // authorized to access this resource
        }
    }
