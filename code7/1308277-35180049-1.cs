            public static void Register(HttpConfiguration config)
            {
             
                
    
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Formatters.Clear();
                config.Formatters.Add(new BrowserJsonFormatter());
                
                //enum formatter as strings
                config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
                
                // DateTime Formatter
                config.Formatters.JsonFormatter.SerializerSettings
                    .DateFormatString = "o";
    
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                
    
    
    
            }
