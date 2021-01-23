    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(new RedirectAspxPermanentRoute(
                new Dictionary<string, object>() 
                {
                    // Old URL on the left, new route values on the right.
                    { @"/about-us.aspx", new { controller = "Home", action = "About" } },
                    { @"/contact-us.aspx", new { controller = "Home", action = "Contact" }  }
                })
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
