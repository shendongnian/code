        public static void Register(HttpConfiguration config)
        {
            // ...
            // ApiNLogLogger is a custom logger, that uses NLog
            config.Services.Add(typeof(IExceptionLogger), new ApiNLogLogger());
        }
