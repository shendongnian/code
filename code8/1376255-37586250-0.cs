	[TestClass]
	public class PairingTest
	{
		[TestMethod, TestCategory("Temp")]
		public void PairedObservableTest()
		{
			var scheduer = new TestScheduler();
	
			/*
			Legend 
				a = aSource (CoordMetrics)
				b = bSource (CoordData)
				r = expected result
	
	
			a	----2--1-----------1--2--2-----
					2  1           2  1  2
	
			b	-2--------1--2--1-----------2--
				 1        2  2  1           2
	
			r	-------------2--1--1--2--2--2--
							 2  1  2  1  2  2
			*/
			var aSource = scheduer.CreateColdObservable<CoordMetrics>(
				ReactiveTest.OnNext(5, new CoordMetrics(2, 2)),
				ReactiveTest.OnNext(8, new CoordMetrics(1, 1)),
				ReactiveTest.OnNext(20, new CoordMetrics(1, 2)),
				ReactiveTest.OnNext(23, new CoordMetrics(2, 1)),
				ReactiveTest.OnNext(26, new CoordMetrics(2, 2))
			);
			var bSource = scheduer.CreateColdObservable<CoordData>(
				ReactiveTest.OnNext(2, new CoordData(2, 1)),
				ReactiveTest.OnNext(11, new CoordData(1, 2)),
				ReactiveTest.OnNext(14, new CoordData(2, 2)),
				ReactiveTest.OnNext(17, new CoordData(1, 1)),
				ReactiveTest.OnNext(29, new CoordData(2, 2))
			);
			
			var testObserver = scheduer.CreateObserver<string>();
			Implementation(aSource, bSource)
				.Subscribe(testObserver);
	
			
	
			scheduer.Start();
	
			ReactiveAssert.AreElementsEqual(
				new[] {
						ReactiveTest.OnNext(14, "2,2"),
						ReactiveTest.OnNext(17, "1,1"),
						ReactiveTest.OnNext(20, "1,2"),
						ReactiveTest.OnNext(23, "2,1"),
						ReactiveTest.OnNext(26, "2,2"),
						ReactiveTest.OnNext(29, "2,2")
					},
				testObserver.Messages
			);
		}
	
		private static IObservable<string> Implementation(IObservable<CoordMetrics> aSource, IObservable<CoordData> bSource)
		{
			return Observable.Create<string>(observer =>
			{
				var aShared = aSource.Publish();
				var bShared = bSource.Publish();
	
				var fromA = aShared.SelectMany(a => bShared
						//Find matching values from B's
						.Where(b => a.X == b.X && a.Y == b.Y)
						//Only run until another matching A is produced
						.TakeUntil(aShared.Where(a2 => a2.X == a.X && a2.Y == a.Y))
						//Project/Map to required type.
						.Select(b => new CoordBundle(a.X, a.Y /*,  a.Metrics, b.Data*/ ))
					);
	
				var fromB = bShared.SelectMany(b => aShared
						//Find matching values from A's
						.Where(a => a.X == b.X && a.Y == b.Y)
						//Only run until another matching B is produced
						.TakeUntil(bShared.Where(b2 => b2.X == b.X && b2.Y == b.Y))
						//Project/Map to required type.
						.Select(a => new CoordBundle(a.X, a.Y /*,  a.Metrics, b.Data*/ ))
					);
	
				var paired = Observable.Merge(fromA, fromB);
	
				paired
					.Select(g => String.Format("{0},{1}", g.X, g.Y))
					.Subscribe(observer);
	
				return new CompositeDisposable(aShared.Connect(), bShared.Connect());
			});
		}
	}
	
	// Define other methods and classes here
	public class CoordMetrics
	{
		internal CoordMetrics(int x, int y)
		{
			X = x;
			Y = y;
		}
		internal int X { get; private set; }
		internal int Y { get; private set; }
	}
	
	public class CoordData
	{
		internal CoordData(int x, int y)
		{
			X = x;
			Y = y;
		}
	
		internal int X { get; private set; }
		internal int Y { get; private set; }
	}
	
	public class CoordBundle
	{
		internal CoordBundle(int x, int y)
		{
			X = x;
			Y = y;
		}
	
		internal int X { get; private set; }
		internal int Y { get; private set; }
	}
	public class Pair
	{
		public Pair(CoordMetrics x, CoordData y)
		{
			Item1 = x;
			Item2 = y;
		}
		public CoordMetrics Item1 { get; set; }
		public CoordData Item2 { get; set; }
	}
