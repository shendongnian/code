    public void Configuration(IAppBuilder app)
    {
        ...
        app.UseGlobalization(new OwinGlobalizationOptions("en-US",true)
           .DisablePaths("Content", "bundles")
           .Add("fr-FR", true).AddCustomSeeker(new CultureFromPreferences()));
    }
