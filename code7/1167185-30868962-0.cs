    [SetUp]
    public void CreateIMyInterfaceImpl() {
        var container = new UnityContainer();
        // Register the Types that implement the interfaces needed by
        // the Type we're testing.
        // Ideally for Unit Tests these should be Test Doubles.
        container.RegisterType<IDependencyOne, DependencyOneStub>();
        container.RegisterType<IDependencyTwo, DependencyTwoMock>();
        // Have Unity create an instance of T for us, using all
        // the required dependencies we just registered
        _impl = container.Resolve<T>();   
    }
    
