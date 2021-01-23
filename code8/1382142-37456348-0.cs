    public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        var builder = new ContainerBuilder();
        // Register the components we need resolving with Autofac
        builder.RegisterInstance(applicationContext.Services.MemberService).As<IMemberService>();
        builder.RegisterInstance(applicationContext.Services.ContentService).As<IContentService>();
        // ... Configuration for dependency resolution here ...
    }
