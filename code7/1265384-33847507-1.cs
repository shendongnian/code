	private static void ThreadStuff()
	{
		long startSet = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
		List<long> endSet = new List<long>();
		for (var i = 0; i <= 20000; i++)
		{
			Action Act = new Action(() => Test(i));
		
			Task Tsk = new Task(Act);
			Tsk.Start();
			endSet.Add(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64);
			int worker;
			int ioCompletion;
			ThreadPool.GetMaxThreads(out worker, out ioCompletion);
			Console.WriteLine(worker);
			Console.WriteLine(ioCompletion);
		}
		Console.WriteLine(startSet.ToString("###,###,###,###,###,###.####"));
		Console.WriteLine(endSet.Average().ToString("###,###,###,###,###,###.####"));
	}
	public static void Test(int Index)
	{
		Thread.Sleep(2000);
		Console.WriteLine(Index.ToString() + " Done");
	}
