    public class CustomIocDependencyResolver : IDependencyResolver
    {
        private readonly CustomIoc container;
        public ComponentLoaderWebApiDependencyResolver(CustomIoc container)
        {
            this.container = container;
        }
        IDependencyScope IDependencyResolver.BeginScope()
        {
            return new CustomIocDependencyResolver(container);
        }
        Object IDependencyScope.GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }
        IEnumerable<Object> IDependencyScope.GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType);
        }
        public void Dispose()
        {
        }
    }
