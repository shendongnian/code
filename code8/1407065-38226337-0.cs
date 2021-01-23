    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var routeValues = httpContext.Request.RequestContext.RouteData.Values;
            if (httpContext.User.IsInRole("Admin"))
                return true;
            var controller = routeValues["Controller"];
            var action = routeValues["Action"];
            return base.AuthorizeCore(httpContext);
        }
    }
