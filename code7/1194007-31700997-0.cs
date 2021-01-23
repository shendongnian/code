    public void WhenConsumingFromBlockingCollection_GivenLimitOfTwoThreads_TwoThreadsAreUsed()
    {
		var taskFactory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(2));
		var scheduler = new TaskPoolScheduler(taskFactory);
		var iterationCount = 100;
		Observable
			.Range(0, iterationCount)
			.SelectMany(n => Observable.Start(() => n.ToString(), scheduler)
			.Do(x => Go(x)))
			.Wait();
			
        (iterationCount ==  _testStrings.Count).Dump();
        (2 == _threadIds.Distinct().Count()).Dump();
    }
