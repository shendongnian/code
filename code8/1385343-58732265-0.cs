    public static void ConfigureDependencyInjection(HttpConfiguration config)
            {
    
                var builder = new ContainerBuilder();
                
                // Register your Web API controllers.
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    
                // OPTIONAL: Register the Autofac filter provider.
                builder.RegisterWebApiFilterProvider(config);
    
                // OPTIONAL: Register the Autofac model binder provider.
                builder.RegisterWebApiModelBinderProvider();
    
                // Set the dependency resolver to be Autofac.
                var container = builder.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                
            }
