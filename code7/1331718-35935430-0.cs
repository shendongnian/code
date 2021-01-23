    public void ConfigureAuth(IAppBuilder app)
    {
        app.CreatePerOwinContext(()=> DependencyResolver.Current.GetService<ApplicationUserManager>());
        app.CreatePerOwinContext(()=> DependencyResolver.Current.GetService<ApplicationSignInManager>());
        // other configs
    }
