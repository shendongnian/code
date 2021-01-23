    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Some more config here
            config.Filters.Add(new IdentityBasicAuthenticationAttribute());
        }
    }
