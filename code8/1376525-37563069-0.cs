	void Main()
	{
		TestScheduler scheduler = new TestScheduler();
		/*
	|--2A-------1A----------
	|----1B----------2B-----
	|------1C-----------2C--
	|-----------1ABC----2ABC   <- zipped by key 1 & 2 respectively
		
		*/
		var sourceA = scheduler.CreateColdObservable(
			ReactiveTest.OnNext(3, "2A"),
			ReactiveTest.OnNext(12, "1A"));
		var sourceB = scheduler.CreateColdObservable(
			ReactiveTest.OnNext(5, "1B"),
			ReactiveTest.OnNext(17, "2B"));
		var sourceC= scheduler.CreateColdObservable(
			ReactiveTest.OnNext(7, "1C"),
			ReactiveTest.OnNext(20, "2C"));
	
		var observer = scheduler.CreateObserver<string>();
		
		
		var query = Observable.Merge(sourceA, sourceB, sourceC)
			.GroupBy(x => GetKey(x))
			.SelectMany(grp => grp.Select(x=>GetValue(x))
								  .Take(3)
								  .Aggregate(new List<string>(), 
								  			(accumulator, current) => { 
												accumulator.Add(current); 
												return accumulator;
											})
								.Select(acc=>CreateGroupResult(grp.Key, acc)));
		
		query.Subscribe(observer);
		scheduler.Start();
	
		ReactiveAssert.AreElementsEqual(
			new[]{
				ReactiveTest.OnNext(12, "1ABC"),
				ReactiveTest.OnNext(20, "2ABC")
			},
			observer.Messages
		);
		
	}
	
	// Define other methods and classes here
	private static string CreateGroupResult(string key, IEnumerable<string> values)
	{
		var combinedOrderedValues = string.Join(string.Empty, values.OrderBy(v => v));
		return string.Format("{0}{1}", key, combinedOrderedValues);
	}
	
	private static string GetKey(string message)
	{
		return message.Substring(0, 1);
	}
	
	private static string GetValue(string message)
	{
		return message.Substring(1);
	}
