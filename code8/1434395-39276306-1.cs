    public interface IServiceByNameFactory<out TService>
    {
        TService GetByName(string name);
    }
    
    public static class FactoryServiceCollectionExtensions
    {
        public static ServicesByNameBuilder<TService> AddByName<TService>(this IServiceCollection services)
        {
            return new ServicesByNameBuilder<TService>(services);
        }
    }
    
    public class ServicesByNameBuilder<TService>
    {
        private readonly IServiceCollection _services;
    
        private readonly IDictionary<string, Type> _registrations
            = new Dictionary<string, Type>();
    
        internal ServicesByNameBuilder(IServiceCollection services)
        {
            _services = services;
        }
    
        public ServicesByNameBuilder<TService> Add(string name, Type implemtnationType)
        {
            _registrations.Add(name, implemtnationType);
            return this;
        }
    
        public ServicesByNameBuilder<TService> Add<TImplementation>(string name)
            where TImplementation : TService
        {
            return Add(name, typeof(TImplementation));
        }
    
        public void Build()
        {
            var registrations = _registrations;
            _services.AddTransient<IServiceByNameFactory<TService>>(s => new ServiceByNameFactory<TService>(s, registrations));
        }
    }
    
    internal class ServiceByNameFactory<TService> : IServiceByNameFactory<TService>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<string, Type> _registrations;
    
        public ServiceByNameFactory(IServiceProvider serviceProvider, IDictionary<string, Type> registrations)
        {
            _serviceProvider = serviceProvider;
            _registrations = registrations;
        }
    
        public TService GetByName(string name)
        {
            Type implementationType;
            if (!_registrations.TryGetValue(name, out implementationType))
                throw new ArgumentException("No service is registered for given name");
            return (TService) _serviceProvider.GetService(implementationType);
        }
    }
