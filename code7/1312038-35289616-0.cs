	var ob = Observable.Interval(TimeSpan.FromMilliseconds(100));
	ob.Subscribe(l =>
	{
		Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
		Thread.Sleep(1000); // slow processing of events
		Console.WriteLine("Latest: " + l);
	});
	ob.Subscribe(l =>
	{
		Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
		Thread.Sleep(1000); // slow processing of events
		Console.WriteLine("Latest1: " + l);
	});
