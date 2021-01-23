    services.AddSingleton(serviceType => Configuration);
    services.AddInstance<Microsoft.Extensions.Configuration.IConfiguration>(Configuration);
    builder.Populate(services);
    var container = builder.Build();
    var serviceProvider = container.Resolve<IServiceProvider>();
    return serviceProvider;
