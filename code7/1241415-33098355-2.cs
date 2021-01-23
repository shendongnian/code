	static void Main(string[] args)
	{
		TaskScheduler.UnobservedTaskException += (s,e) => Console.WriteLine(e.Exception);
		
		for (int i = 0; i < 10; i++)
		{
			Task.Factory.StartNew(() =>
			{
				MultithreadedMethod();
			});
		}
	
		Thread.Sleep(2000);
		Console.WriteLine(count);
	}
	
