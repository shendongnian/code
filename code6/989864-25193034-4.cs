    public static class WebApiConfig{
            public static void Register(HttpConfiguration config){            
                config.Routes.MapHttpRoute(
                    name: "apiSample",
                    routeTemplate: "api/{action}/{controller}",
                );
    
         ...
