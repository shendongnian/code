    builder.RegisterAssemblyTypes(Assembly.Load("Services"))
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces()
           .AsSelf();
           .InstancePerLifetimeScope();
