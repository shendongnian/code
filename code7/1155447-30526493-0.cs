    class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }
        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }
        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }
        public void Dispose()
        {
        }
    }
    class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;
        public WindsorDependencyScope(IWindsorContainer container)
        {
            _container = container;
            _scope = container.BeginScope();
        }
        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }
        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
