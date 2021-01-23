    public void MyMethod()
    {
        MyMethodAsync().Wait();
    }
    
    public Task MyMethodAsync()
    {
        // do some stuff
    }
