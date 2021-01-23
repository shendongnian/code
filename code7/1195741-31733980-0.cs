        public static class WebApiConfig
        {
          public static void Register(HttpConfiguration config)
          {
            // Prevent "Self referencing loop detected" error occurring for recursive objects
            var serializerSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            config.Formatters.JsonFormatter.SerializerSettings = serializerSettings;
          }
        }
