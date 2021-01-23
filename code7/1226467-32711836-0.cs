    public IMyService client { get; set; }
    
    public MyClass(IMyService myservice)
    {
        MyService = myservice
    }
