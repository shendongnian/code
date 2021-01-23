    public static void Register(HttpConfiguration config)
    
            {
                //config.Routes.MapHttpRoute(
                //    name: "DefaultApi",
                //    routeTemplate: "api/{controller}/{id}",
                //    defaults: new { id = RouteParameter.Optional });
    
               config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
               new { id = RouteParameter.Optional });
                
            }
