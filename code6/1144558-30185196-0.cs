    public class LightCoreSignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly IContainer _container;
    
        public LightCoreSignalRDependencyResolver(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            _container = container;
        }
    
        public **override** object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            // IDependencyResolver implementations must not throw an exception 
            // but return null if type is not registered
            catch (RegistrationNotFoundException registrationNotFoundException)
            {
                return base.GetService(serviceType);
            }
        }
    
        public **override** IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return  _container.ResolveAll(serviceType).Concat(base.GetServices(serviceType));
            }
            // IDependencyResolver implementations must not throw an exception 
            // but return an empty object collection if type is not registered
            catch (RegistrationNotFoundException registrationNotFoundException)
            {
                return base.GetServices(serviceType);
            }
        }
    }
