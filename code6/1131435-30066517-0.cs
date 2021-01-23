    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var username = filterContext.HttpContext.User.Identity.Name;
            if (username != "")
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
    }
