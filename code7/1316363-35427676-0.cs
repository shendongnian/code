            public Func<T> HttpRequestScopedFactoryFor<T>()
            {
                return () => DependencyResolver.Current.GetService<T>();
            }
    
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType(typeof(DerivedDbContext)).AsSelf().InstancePerRequest();
                builder.RegisterInstance(HttpRequestScopedFactoryFor<DerivedDbContext>());
            }
