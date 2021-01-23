            public Func<T> HttpRequestScopedFactoryFor<T>()
            {
                return () => DependencyResolver.Current.GetService<T>();
            }
    
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<BusinessTypeService>.As<IBusinessTypeService>().InstancePerRequest();
                builder.RegisterInstance(HttpRequestScopedFactoryFor<IBusinessTypeService>());
            }
