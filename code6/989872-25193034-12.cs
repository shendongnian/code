    public static class WebApiConfig{
            public static void Register(HttpConfiguration config){            
                config.Routes.MapHttpRoute(
                    name: "apiSample",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = System.Web.Http.RouteParameter.Optional  }
                );
    
         ...
