	// Define other methods and classes here
	public void TestObserveOnSeparateTask()
	{
		var scheduler = new TestScheduler();
		var source = scheduler.CreateColdObservable<int>(
			ReactiveTest.OnNext(TimeSpan.FromSeconds(1).Ticks, 3),
			ReactiveTest.OnNext(TimeSpan.FromSeconds(2).Ticks, 2),
			ReactiveTest.OnNext(TimeSpan.FromSeconds(3).Ticks, 1),
			ReactiveTest.OnCompleted<int>(TimeSpan.FromSeconds(4).Ticks)
			);
		
		var observer = scheduler.CreateObserver<int>();
		var subscription = source
			.ObserveOn(scheduler)
	//		.Subscribe(
	//			o =>
	//			{
	//				Console.WriteLine("Received {1} on threadId:{0}", Thread.CurrentThread.ManagedThreadId, o);
	//				//Task.Delay(1000 * o);
	//			},
	//			() => Console.WriteLine("OnCompleted on threadId:{0}",
	//				Thread.CurrentThread.ManagedThreadId));
			.Subscribe(observer);
		
		scheduler.Start();
	
		//Pretty silly test, as we apply no query/projection to the source.
		//	Note we add 1 tick due to it being a relative/cold observable and the ObserveOn scheduling will take one time slice to perform.
		ReactiveAssert.AreElementsEqual(
			new[] {
				ReactiveTest.OnNext(TimeSpan.FromSeconds(1).Ticks + 1, 3),
				ReactiveTest.OnNext(TimeSpan.FromSeconds(2).Ticks + 1, 2),
				ReactiveTest.OnNext(TimeSpan.FromSeconds(3).Ticks + 1, 1),
		        ReactiveTest.OnCompleted<int>(TimeSpan.FromSeconds(4).Ticks + 1)
			},
			observer.Messages);
	}
