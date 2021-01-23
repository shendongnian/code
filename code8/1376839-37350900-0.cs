    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Insert(typeof(ModelBinderProvider), 0,
                new SimpleModelBinderProvider(typeof(RecordCollection), new JsonBodyModelBinder<RecordCollection>()));
        }
    }
