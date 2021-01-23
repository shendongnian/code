    //Inside App_Start\WebApiConfig.cs
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Map all Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
