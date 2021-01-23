    public void ConfigureAuth(IAppBuilder app)
    {
       app.UseCookieAuthentication(new CookieAuthenticationOptions
       {
          AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
          LoginPath = new PathString("/Account/Login"),
          CookieSecure = CookieSecureOption.Always,
          SessionStore = new MyAuthenticationSessionStore()
       });
    }    
