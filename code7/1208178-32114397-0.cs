        public static class WebApiConfig
            {
                public static void Register(HttpConfiguration config)
                {
                    // Web API configuration and services
                    // Configure Web API to use only bearer token authentication.
                    config.SuppressDefaultHostAuthentication();
                    config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
        
                    // Web API routes
                    config.MapHttpAttributeRoutes();
        
                    config.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/Test",
                        defaults: new { controller = "Test", action = "GetA"}
                    );
    
     config.Routes.MapHttpRoute(
                        name: "WithID",
                        routeTemplate: "api/Test/{id}",
                        defaults: new { controller = "Test", action = "GetB", id = UrlParameter.Optional }
                    );
    
     config.Routes.MapHttpRoute(
                        name: "ALL",
                        routeTemplate: "api/Test/all",
                        defaults: new { controller = "Test", action = "GetC"}
                    );
                }
        }
