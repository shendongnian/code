    public void ConfigureAuth(IAppBuilder app)
    {
        // other stuff
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            ExpireTimeSpan = TimeSpan.FromHours(1),
        });            
    }
