    static Task D4()
    {
    	Console.Write("Enter the divisor: ");
    	var n = int.Parse(Console.ReadLine());
    	Console.WriteLine((24 / n).ToString());
    
    	// return new TaskCompletionSource<object>().Task;
    	// return Task.FromResult<object>(null);
    	// return Task.FromResult<bool>(false);
    	// return Task.FromResult(0);
    
    	return default(Task);
    }
