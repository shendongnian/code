    public static void RegisterComponents()
    {
        var builder = new ContainerBuilder();
        
            builder.RegisterType<DatabaseContext>()
                .InstancePerLifetimeScope()
                .As<IDatabaseContext>();
        // further registrations
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
