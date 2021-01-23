    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // existing stuff
           config.Formatters
                .JsonFormatter
                .SerializerSettings
                .DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffK";
        }
    }
