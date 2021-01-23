        builder.RegisterAssemblyTypes(typeof(IClientElementRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();
        // Services
                builder.RegisterAssemblyTypes(typeof(IClientElementService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerRequest();
    
    builder.RegisterAssemblyTypes(typeof(IMappingBaseService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerRequest();
