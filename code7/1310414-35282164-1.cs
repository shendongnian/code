    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            //Order handlers are added is important. First in last out
            config.MessageHandlers.Add(new WebApiRateLimitHandler());
            config.MessageHandlers.Add(new SomeOtherMessageHandler());
    
            // Other code not shown...
        }
    }
