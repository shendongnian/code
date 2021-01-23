    app.CreatePerOwinContext(dbEmployeePortal.Create);
    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
    
    
    PathString path = new PathString("/Account/Login");
    if (GlobalExtensions.WindowsAuthActive)
        path = new PathString("/Windows/Login");
    
    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //LoginPath = new PathString("/Account/Login")
        LoginPath = path
    });
    // Use a cookie to temporarily store information about a user logging in with a third party login provider
    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
