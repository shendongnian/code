    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Converters.Add(new BsonDocumentJsonConverter());
        }
    }
