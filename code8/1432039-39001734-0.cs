	var scheduler = new QueuedTaskScheduler(TaskScheduler.Default, 2);
	
	var jobAction = new Action<string>(
		jobName =>
		{
			Console.WriteLine("I am job " + jobName + " and I start at " + DateTime.Now.ToLongTimeString());
			Thread.Sleep(10000);
			Console.WriteLine("I am job " + jobName + " and I finish at " + DateTime.Now.ToLongTimeString());
		});
	
	var jobs = Enumerable
		.Range(1, 6)
		.Select(num => Task.Factory.StartNew(
			() => jobAction("Job" + num),
			CancellationToken.None,
			TaskCreationOptions.LongRunning,
			scheduler))
		.ToList();
		
	Task.WhenAll(jobs).Wait();
