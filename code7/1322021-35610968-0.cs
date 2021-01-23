	void Main()
	{
		CancellationTokenSource src = new CancellationTokenSource();
		CancellationToken ct = src.Token;
		ct.Register(() => Console.WriteLine("Abbruch des Tasks"));
		
		Task t = Task.Run(() =>
		{
			System.Threading.Thread.Sleep(1000);
			ct.ThrowIfCancellationRequested();
		}, ct);
		
		src.Cancel();
		try
		{
			t.Wait();
		}
		catch (AggregateException e)
		{
			// Don't actually use an empty catch clause, this is
			// for the sake of demonstration.
		}
		
		Console.WriteLine("Canceled: {0} . Finished: {1} . Error: {2}",
						   t.IsCanceled, t.IsCompleted, t.IsFaulted);
	}
