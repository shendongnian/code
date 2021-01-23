    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(new RedirectAspxPermanentRoute(
                new Dictionary<string, string>() 
                {
                    // If URL is what is on the left, 301 to URL on the right
                    { @"/about-us.aspx", @"/home/about" },
                    { @"/contact-us.aspx", @"/home/contact" }
                })
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
