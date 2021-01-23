    public class ElmahRequestAuthorizationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
    
            if (filterContext.IsChildAction) return;
    
            var controller = filterContext.RouteData.Values["controller"] as string;
    
            if (controller != null && controller.ToLowerInvariant() != "elmah") return;
    
            var authenticationComponent = GetAuthenticationInfo() // A method that will return us roles;
    
            var goodRoles = new List<string> {
                "TestRole",
                "ThirdLevelSupport",
                "Administrator"
            };
    
            var roles = authenticationComponent.Roles ?? new List<string>();
    
            var thouShaltPass = roles.Intersect(goodRoles).Any();
    
            if (!thouShaltPass)
            {
                throw new HttpException(404, "Not Found");
            }
    
        }
    }
