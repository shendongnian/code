    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                // Redirect to login page
                filterContext.Result = Redirect("Login", "Index");
                return;
            }
    
            var roles = GetRolesFromDb();
            if (!Roles.Any(r => roles.Contains(r)))
                filterContext.Result = Redirect("Error", "AccessDenied");
        }
    
        private RedirectToRouteResult Redirect(string controller, string action, string area = "")
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller,
                action,
                area,
            });
        }
    }
