        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                // Existing route register code
                // Custom route - top priority
                routes.MapRoute(
                        name: "PageSlug", 
                        url: "{slug}", 
                        defaults: new { controller = "Pages", action = "DetailSlug" },
                        constraints: new {
                            slug = ".+", // Passthru for no slug (goes to home page)
                            slugMatch = new PageSlugMatch() // Custom constraint
                        }
                    );
                }
                // Default MVC route setup & other custom routes
            }
        }
