    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "User",
                url: "{username}",
                defaults: new { controller = "User", action = "Index" },
                constraints: new { username = new UserNameConstraint() }
            );
            routes.MapRoute(
                name: "UserPhotos",
                url: "{username}/Photos",
                defaults: new { controller = "User", action = "Photos" },
                constraints: new { username = new UserNameConstraint() }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional }
            );
        }
        public class UserNameConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                List<string> users = new List<string>() { "Bryan", "Stephen" };
                // Get the username from the url
                var username = values["username"].ToString().ToLower();
                // Check for a match (assumes case insensitive)
                return users.Any(x => x.ToLower() == username);
            }
        }
    }
