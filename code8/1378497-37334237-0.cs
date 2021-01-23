    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) {
    
          config.Routes.MapHttpRoute(
              name: "CustomerApi_GetCustomer",
              routeTemplate: "api/Customer/{id}",
              defaults: new { controller = "Customer" action = "GetCustomer" }
          );
    
          config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
    
          config.Routes.MapHttpRoute(
               name: "ApiWithAction",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           ); 
        }
    }
