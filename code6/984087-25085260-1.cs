    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new HandleSerializationErrorAttribute());
            config.Formatters.RemoveAt(0);
            var serializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error
            };
            config.Formatters.Insert(0, new JsonTextFormatter(serializerSettings));
        }
    }
