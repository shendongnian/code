    public static class WebApiConfig {
    
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }
    
        public static void Register(HttpConfiguration config) {
             //Enable Web API Attribute routing.
             config.MapHttpAttributeRoutes();
    
            // Other Web API configuration
            config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}/{id}",
             defaults: new { id = RouteParameter.Optional }
            );
    
            config.Routes.MapHttpRoute(
               name: "DefaultApi2",
               routeTemplate: WebApiConfig.UrlPrefix + "/{controller}" 
            );
        }
    }
