	Task<Test> task2 = Task.Factory.StartNew(() =>
	{
		string s = ".NET";
		double d = 4.0;
		for (int i = 0; i < 3; i++) { }
		return new Test { Name = s, Number = d };
	});
	
	task2.ContinueWith(t =>
	{
		// This runs when things are done
		Test tt = t.Result;
		// use tt
	}, TaskScheduler.FromCurrentSynchronizationContext());
