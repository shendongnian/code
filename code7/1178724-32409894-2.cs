    public void ConfigureAuth(IAppBuilder app)
    {
        app.UseSteamAuthentication("ABCDEFGHIJKLMNOPQRSTUVWXYZ"); //if you put it here, it won't work
        // Configure the db context, user manager and signin manager to use a single instance per request
        app.CreatePerOwinContext(ApplicationDbContext.Create);
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            
        //rest of the code here
    }
