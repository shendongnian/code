    services.Scan(scan => scan
                .FromAssemblies(<<TYPE>>.GetTypeInfo().Assembly)
                    .AddClasses(classes => classes.Where(x => {
                        var allInterfaces = x.GetInterfaces();
                        return 
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IRepository<>)));
                    }))
                    .AsSelf()
                    .WithTransientLifetime()
            );
