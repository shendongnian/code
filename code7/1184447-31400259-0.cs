	void Main()
	{
		var timer = Observable.Interval(TimeSpan.FromMilliseconds(100));
		using (timer.Do(x => Console.WriteLine("!")).Subscribe(tick => DoSomething()))
		{
			Console.ReadLine();
		}
	}
	
	private void DoSomething()
	{
		Console.Write("<");
		Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
		Thread.Sleep(1000);
		Console.WriteLine(">");
	}
