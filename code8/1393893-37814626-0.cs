	void Main()
	{
		var scheduler = new TestScheduler();
		var stream = scheduler.CreateColdObservable(
			ReactiveTest.OnNext(1.Seconds(), 'A'),
			ReactiveTest.OnNext(2.Seconds(), 'B'),
			ReactiveTest.OnNext(13.Seconds(), 'C')
			);
		
		var observer = scheduler.CreateObserver<string>();
	
		var query = stream.Publish(s => {
			return s.Timeout(TimeSpan.FromSeconds(10), Observable.Empty<char>(), scheduler)
				.ToList()
				.Where(buffer=>buffer.Any())	
				//Project to string to make equality test easier for the example.		
				.Select(buffer=>string.Join(",", buffer))
				.Repeat();
		});
	
		query.Subscribe(observer);
	
		scheduler.AdvanceBy(100.Seconds());
	
		ReactiveAssert.AreElementsEqual(
			new []{
				ReactiveTest.OnNext(12.Seconds(), "A,B"),
				ReactiveTest.OnNext(23.Seconds(), "C")
			},
			observer.Messages);
	}
	
	// Define other methods and classes here
	public static class TimeEx
	{
		public static long Seconds(this int seconds)
		{
			return TimeSpan.FromSeconds(seconds).Ticks;
		}
	}
