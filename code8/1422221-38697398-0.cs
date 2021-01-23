    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.BindParameter(typeof(Instant), new InstantModelBinder())
            ...
        }
    }
