    public class FactoryBuilder<I, P> where I : class
    {
        private readonly IServiceCollection _services;
        private readonly FactoryTypes<I, P> _factoryTypes;
        public FactoryBuilder(IServiceCollection services)
        {
            _services = services;
            _factoryTypes = new FactoryTypes<I, P>();
        }
        public FactoryBuilder<I, P> Add<T>(P p)
            where T : class, I
        {
            _factoryTypes.ServiceList.Add(p, typeof(T));
            _services.AddSingleton(_factoryTypes);
            _services.AddTransient<T>();
            return this;
        }
    }
    public class FactoryTypes<I, P> where I : class
    {
        public Dictionary<P, Type> ServiceList { get; set; } = new Dictionary<P, Type>();
    }
    public interface IFactory<I, P>
    {
        I Create(P p);
    }
    public class Factory<I, P> : IFactory<I, P> where I : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly FactoryTypes<I, P> _factoryTypes;
        public Factory(IServiceProvider serviceProvider, FactoryTypes<I, P> factoryTypes)
        {
            _serviceProvider = serviceProvider;
            _factoryTypes = factoryTypes;
        }
        public I Create(P p)
        {
            return (I)_serviceProvider.GetService(_factoryTypes.ServiceList[p]);
        }
    }
