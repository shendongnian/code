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
        public static void ResolverForCurrentScope<T>(this IServiceContainer container, Func<IServiceFactory, T> factory)
            where T : class
        {
            var scope = container.ScopeManagerProvider.GetScopeManager().CurrentScope;
            container.GetInstance<ScopedStorage>().Register<T>(() =>
            {
                var instance = factory(container);
                var disposable = instance as IDisposable;
                if (disposable != null)
                    scope.TrackInstance(disposable);
                return instance;
            });
        }
