    public IMyService client { get; set; }
    
    public MyClass(IMyService myservice)
    {
        client = myservice
    }
