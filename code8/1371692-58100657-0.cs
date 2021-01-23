    public class DefaultDependecyResolver : IDependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public DefaultDependecyResolver(IServiceProvider serviceProvider)
            => this.ServiceProvider = serviceProvider;
        public IDependencyScope BeginScope() => this;
        public object GetService(Type serviceType)
            => this.ServiceProvider.GetService(serviceType);
        public IEnumerable<object> GetServices(Type serviceType)
            => this.ServiceProvider.GetServices(serviceType);
        public void Dispose() { }
    }
