        public static class WebApiConfig
        {
           public static void Register(HttpConfiguration config)
           {
            // New code
            config.EnableCors();    
          }
        }
