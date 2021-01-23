          public static class WebApiConfig
            {
              public static void Register(HttpConfiguration config)
              {
                // Web API configuration and services
    
                // Adding the Generic Exception Filter for the application
                config.Filters.Add(new ViewRExceptionFilterAttribute());
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute("ControllerActionApi", "api/{controller}/{action}/{userID}",
                    new {userID = RouteParameter.Optional}
                    );
    
                config.Routes.MapHttpRoute("ControllerApi", "api/{controller}/{userID}",
                    new {userID = RouteParameter.Optional}
                    );
              }
           }
