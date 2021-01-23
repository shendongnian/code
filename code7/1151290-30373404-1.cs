    public void ConfigureAuth(IAppBuilder app)
    {
        // .. more here but omitted
    
        // Enable the application to use a cookie to store information for the signed in user
        // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        // Configure the sign in cookie
        app.UseCookieAuthentication(
            new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    
                // YOUR LOGIN PATH HERE
                LoginPath = new PathString("/Account/Login"),
    
                // .. more here but omitted
            });
    }
