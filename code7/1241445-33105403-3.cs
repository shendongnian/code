    public class Factory
    {
        private readonly IUnityContainer _container;
        private readonly HashSet<string> _classes = new HashSet<string>();
        public Factory(IUnityContainer container)
        {
            _container = container;
        }
        public void Register<TInterface, TClass>(string alias) where TClass : TInterface
        {
            _classes.Add(alias);
            _container.RegisterType<TInterface, TClass>(alias);
        }
        public TInterface Resolve<TInterface>(string alias)
        {
            if (_classes.Contains(alias))
                return _container.Resolve<TInterface>(alias);
            return _container.Resolve<TInterface>("default");
        }
    }
    var factory = new Factory(container);
    factory.Register<IFoo, FooOne>("One");
    IFoo foo = factory.Resolve<IFoo>(AliasString);
