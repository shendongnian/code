        readonly Lazy<JsonSerializerSettings> settings = new Lazy<JsonSerializerSettings>(JsonConvert.DefaultSettings);
        public JsonSerializerSettings Settings => settings.Value;
        public override void Configure(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            base.Configure(controllerSettings, controllerDescriptor);
            controllerSettings.Formatters.JsonFormatter.SerializerSettings = Settings;
        }
    }
