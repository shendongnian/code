	Task<Task> task1 = new Task<Task>(new Func<Task>(async () =>
	{
		Trace.WriteLine("before delay");
		await Task.Delay(1000);
		Trace.WriteLine("after delay");
	}));
	var task2 = task1.Unwrap();
	var task3 = task2.ContinueWith(task => Trace.WriteLine("continued"));
	task1.Start();
	task3.Wait();
