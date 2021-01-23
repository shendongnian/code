    interface ISomeService { ... }
    class SomeService : ISomeService { ... }
    class IocContainer
    {
        private readonly Dictionary<Type, Func<object>> _factories = new Dictionary<Type, Func<object>>();
        public void Register<T>(Func<T> factory)
            where T: class 
        {
            _factories[typeof(T)] = factory;
        }
        // Note: this is C#6, refactor if not using VS2015
        public T Resolve<T>() => (T)_factories[typeof(T)]();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new IocContainer();
            container.Register<ISomeService>(() => new SomeService());
            // ...
            var service = container.Resolve<ISomeService>();
        }
    }
