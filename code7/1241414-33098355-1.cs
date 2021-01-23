	static void Main(string[] args)
	{
		for (int i = 0; i < 10; i++)
		{
			Task.Factory.StartNew(() =>
			{
				MultithreadedMethod();
			});
		}
	
		TaskScheduler.UnobservedTaskException += (s,e) => Console.WriteLine(e.Exception);
		Thread.Sleep(2000);
		Console.WriteLine(count);
	}
	
