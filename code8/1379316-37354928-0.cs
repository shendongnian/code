    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services  
            //for json objects, we want it to be in camel case
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var settings = formatters.JsonFormatter.SerializerSettings;
    
    
    
            settings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;  
            
    
            // Web API routes
            config.MapHttpAttributeRoutes(); 
        }
    }
