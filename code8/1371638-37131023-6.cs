	void Main()
	{
		var ob = Observable.Interval(TimeSpan.FromMilliseconds(100));
		var d = ob.Subscribe(
			x => ConsumeThrows(x).Wait(),
			ex=> Console.WriteLine("I will not get hit"));
			
		Thread.Sleep(10000);
		d.Dispose();
	}
	
	static async Task<Unit> ConsumeThrows(long count)
	{
		return await Task.FromException<Unit>(new Exception("some failure"));
		//this will have the same effect of bringing down the application.
		//throw new Exception("some failure");
	}
