        public static void Configure(HttpSelfHostConfiguration config)
        {
            Throw.IfNull(config, "config");
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new RdfNotificationJsonConverter());
         } 
