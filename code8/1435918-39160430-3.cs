    // in Global.asax.cs
    var builder = new ContainerBuilder();
    builder.RegisterModule(new DialogModule());
    builder.RegisterModule(new ReflectionSurrogateModule());
    builder.RegisterModule(new DialogModule_MakeRoot());
    
    var config = GlobalConfiguration.Configuration;
    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    builder.RegisterWebApiFilterProvider(config);
    var container = builder.Build();
    config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
