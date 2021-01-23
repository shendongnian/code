    public override void MyVirtualMethod()
    {
    	Task.Factory.StartNew(()=> SomeTaskMethod());
    }
    
    public override async void MyVirtualMethod()
    {
    	await SomeTaskMethod();
    }
