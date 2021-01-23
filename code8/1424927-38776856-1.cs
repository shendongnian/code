    static volatile int currentExecutionCount = 0;
	static void Main(string[] args)
	{
		List<Task<long>> taskList = new List<Task<long>>();
		var timer = new Timer(Print, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
		for (int i = 0; i < 1000; i++)
		{
			taskList.Add(DoMagic());
		}
		Task.WaitAll(taskList.ToArray());
		timer.Change(Timeout.Infinite, Timeout.Infinite);
		timer = null;
		//to check that we have all the threads executed
		Console.WriteLine("Done " + taskList.Sum(t => t.Result));
		Console.ReadLine();
	}
	static void Print(object state)
	{
		Console.WriteLine(currentExecutionCount);
	}
	static async Task<long> DoMagic()
	{
		return await Task.Factory.StartNew(() =>
		{
			Interlocked.Increment(ref currentExecutionCount);
			//place your code here
			Thread.Sleep(TimeSpan.FromMilliseconds(1000));
			Interlocked.Decrement(ref currentExecutionCount);
			return 4;
		}
		//this thing should give a hint to scheduller to use new threads and not scheduled
		, TaskCreationOptions.LongRunning
		);
	}
