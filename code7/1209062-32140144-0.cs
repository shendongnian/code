     app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login")
        });
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
