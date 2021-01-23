    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
    
            // Web API routes
            config.MapHttpAttributeRoutes();
    
            //config.Filters.Add(new ApiKeyFilter());
    
            config.MessageHandlers.Add(new CustomAuthenticationMessageHandler());
        }
    }
