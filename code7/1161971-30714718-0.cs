    static class ScopedContainerExtensions
    {
        class ScopedContainer
        {
            Dictionary<Type, object> factories = new Dictionary<Type,object>();
            public void Register<T>(Func<T> factory)
                where T: class
            {
                factories.Add(typeof(T), new Lazy<T>(factory));
            }
            public T Resolve<T>()
            {
                return ((Lazy<T>)factories[typeof(T)]).Value;
            }
        }
        public static void UseScopedContainerFor<Service>(this IServiceContainer container)
        {
            if (!container.CanGetInstance(typeof(ScopedContainer), ""))
            {
                container.Register<ScopedContainer>(new PerScopeLifetime());
            }
            container.Register<Service>(sf=>sf.GetInstance<ScopedContainer>().Resolve<Service>());
        }
        public static void ResolverForCurrentScope<T>(this IServiceContainer container, Func<T> factory)
            where T: class
        {
            container.GetInstance<ScopedContainer>().Register<T>(() =>
            {
                var instance = factory();
                var disposable = instance as IDisposable;
                if(disposable != null)
                    container.ScopeManagerProvider.GetScopeManager().CurrentScope.TrackInstance(disposable);
                return instance;
            });
        }
    }
