    async void A()
    {
    	await B(); 
    }
    
    async Task B()
    {
    	// await Task.Factory.StartNew(() => C());
    	await Task.Run(async () => await C());
    	// await Task.Run(() => C()); // this would still produce the same effect
    }
    
    async Task C()
    {
    	while (true)
    	{
    		await Task.Delay(5000);
    		//Thread.Sleep(5000);
    	}
    }
