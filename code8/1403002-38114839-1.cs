    class Factory
    {
        IUnityContainer _container;
        public Factory(IUnityContainer container)
        {
            _container = container;
        }
    
        public void Register<TType>() where TType : MyInterface
        {
            myContainer.RegisterType<MyInterface, TType>(new InjectionFactory(c =>
            {
                var result = c.Resolve<TType>();
                result.MyMethod();
                return result;
            }));
        }
        public MyInterface Get()
        {
            _container.Resolve<MyInterface>();
        }
    }
...
    public TestClass
    {
        Factory _factory;
        public TestClass(Factory factory)
        {
            _factory = factory;
            _factory.Register<MyConcreteType>();
        }
    
        public void TestMethod()
        {
            var service = _factory.Get();
        }
    }
