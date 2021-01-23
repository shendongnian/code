	void Main()
	{
		var scheduler = new TestScheduler();
		var input = scheduler.CreateColdObservable<char>(
			ReactiveTest.OnNext(0100.Ms(), '1'),
			ReactiveTest.OnNext(0500.Ms(), '2'),
			ReactiveTest.OnNext(0800.Ms(), 'A'),
			ReactiveTest.OnNext(1000.Ms(), 'B'),
			ReactiveTest.OnNext(1500.Ms(), 'C'),
			ReactiveTest.OnNext(1800.Ms(), 'A'),
			ReactiveTest.OnNext(2000.Ms(), 'B'),
			ReactiveTest.OnNext(2200.Ms(), '1'),
			ReactiveTest.OnNext(2500.Ms(), 'B'),
			ReactiveTest.OnNext(2700.Ms(), 'A'),
			ReactiveTest.OnNext(3000.Ms(), 'A'));
	
		var expected = scheduler.CreateColdObservable<string>(
			ReactiveTest.OnNext(0100.Ms(), "1"),
			ReactiveTest.OnNext(0500.Ms(), "2"),
			ReactiveTest.OnNext(1000.Ms()+1, "AB"),
			ReactiveTest.OnNext(2000.Ms()+1, "CAB"),
			ReactiveTest.OnNext(2200.Ms(), "1"),
			ReactiveTest.OnNext(3000.Ms()+1, "BAA"));
	
		/*
		                 111111111122222222223
		Time:   123456789012345678901234567890
		Input:  1---2--A-B----C--A-B-1--B-A--A
		Output: 1---2----AB-------CAB-1-----BAA	
		*/
	
		var bufferBoundaries = //Observable.Timer(TimeSpan.FromSeconds(1), scheduler);
				//Move to a hot test sequence to force the windows to close just after the values are produced
				scheduler.CreateHotObservable<Unit>(
			ReactiveTest.OnNext(1000.Ms()+1, Unit.Default),
			ReactiveTest.OnNext(2000.Ms()+1, Unit.Default),
			ReactiveTest.OnNext(3000.Ms()+1, Unit.Default),
			ReactiveTest.OnNext(4000.Ms()+1, Unit.Default));
		
		var publishedFinal = input
			.Publish(i => i
				.Where(c => char.IsLetter(c))
				.Buffer(bufferBoundaries)
				.Where(l => l.Any())
				.Select(lc => new string(lc.ToArray()))
				.Merge(i
					.Where(c => char.IsNumber(c))
					.Select(c => c.ToString())
				)
			);
			
		var observer = scheduler.CreateObserver<string>();
		
		publishedFinal.Subscribe(observer);
		scheduler.Start();
		
        //This test passes with the "+1" values hacked in.
		ReactiveAssert.AreElementsEqual(
			expected.Messages,
			observer.Messages);
	
	}
	
	// Define other methods and classes here
	public static class TickExtensions
	{
		public static long Ms(this int ms)
		{
			return TimeSpan.FromMilliseconds(ms).Ticks;
		}
	}
