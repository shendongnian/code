        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Attribute routing
                config.MapHttpAttributeRoutes();
    
                // Route to index.html
                config.Routes.MapHttpRoute(
                    name: "Index",
                    routeTemplate: "{id}.html",
                    defaults: new {id = "index"});
    
                // Default route
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
