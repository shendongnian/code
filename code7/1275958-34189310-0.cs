    [Inject] public IInjector Injector {get; set;}
    
    void MyClassMethod()
    {
        var instance = this.Injector.Get<ISomeInterface>();
        // etc
    }
