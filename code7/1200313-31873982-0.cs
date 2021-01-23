    interface ISomeService { ... }
    class SomeService : ISomeService { ... }
    class IOCContainer
    {
        private readonly Dictionary<Type, Func<object>> _factories = new Dictionary<Type, Func<object>>();
        public void Register<T>(Func<T> factory)
            where T: class 
        {
            _factories[typeof(T)] = factory;
        }
        public T Resolve<T>() => (T)_factories[typeof(T)]();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new IOCContainer();
            container.Register<ISomeService>(() => new SomeService());
            // ...
            var service = container.Resolve<ISomeService>();
        }
    }
