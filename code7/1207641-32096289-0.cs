    public static class AuthConfig
    {
        public const string DefaultAuthType = "DefaultAppCookie"; //example
        public const string LoginPath = "System/SignIn"; //example
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthType,
                LoginPath = new PathString(LoginPath)
            });
        }
    }
