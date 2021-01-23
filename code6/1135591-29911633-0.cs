	var cts = new CancellationTokenSource();
	cts.CancelAfter(5000);//Request Cancel after 5 seconds
	var newTask = Task.Factory.StartNew(state =>
	{
		int i = 1;
		var token = (System.Threading.CancellationToken)state;
		while (true)
		{
			Console.WriteLine(i);
			i++;
			Thread.Sleep(1000);
			token.ThrowIfCancellationRequested();
		}
	}, cts.Token, cts.Token);
	
	try
	{
		newTask.Wait(10000);
	}
	catch
	{
		Console.WriteLine("Catch:"+ newTask.Status);
	}
