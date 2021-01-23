    public void Configuration(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationMode = AuthenticationMode.Active,
            AuthenticationType = "ApplicationCookie",
            LoginPath = new PathString("/Account/LogOn"),
        });
    }
