    public override void MyVirtualMethod()
    {
        // Will create a non awaited Task (explicitly)
    	Task.Factory.StartNew(()=> SomeTaskMethod());  
    }
    
    public override async void MyVirtualMethod()
    {
        // Will create a non awaited Task (the caller cannot await void)
    	await SomeTaskMethod();  
    }
