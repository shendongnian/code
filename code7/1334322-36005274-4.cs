        container.RegisterType<IDbContext, YourDbContext>(new TransientLifetimeManager());
        container.RegisterType<IInstanceFactory, InstanceFactory>(
                new InjectionConstructor(new List<Func<object>>
                {
                    new Func<IDbContext>(() => container.Resolve<IDbContext>())
                }
            ));
