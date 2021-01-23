    public void ConfigureAuth(IAppBuilder app)
    {
      app.UseCookieAuthentication(new CookieAuthenticationOptions
      {
          ExpireTimeSpan = TimeSpan.FromHours(1),
      });            
    }
