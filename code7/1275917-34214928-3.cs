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
                    name: "route1",
                    routeTemplate: "values"
                    );
    
                config.Routes.MapHttpRoute(
                    name: "route2",
                    routeTemplate: "v2/values");
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );          
    
                config.Services.Replace(
                    typeof(IHttpControllerSelector), 
                    new MyHttpControllerSelector(config));
            }
        }
