    // Services
    builder.RegisterAssemblyTypes(typeof(AppBrandService).Assembly)
       .Where(t => t.Name.EndsWith("Service"))
       .AsImplementedInterfaces()
       .InstancePerRequest();
