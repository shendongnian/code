    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
           config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();            
        }
    }
