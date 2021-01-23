    async Task Main()
    {
    	var tasks = new []{1, 2, 3, 4, 5}.Select(i => OperationAsync(i));
    	
    	foreach(var t in tasks)
    	{
    		await t;
    	}
    	
    	await Task.WhenAll(tasks);
    }
    
    static Random _rand = new Random();
    public async Task OperationAsync(int number)
    {
    	// simulate an asynchronous operation
    	// taking anywhere between 100 to 3000 milliseconds
    	await Task.Delay(_rand.Next(100, 3000));
    	Console.WriteLine(number);
    }
