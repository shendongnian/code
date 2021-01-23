	void Main()
	{
		//In my example GetPrices is the source. 
		//  I meant that you could use an ELS to do some heavy work to get prices.
		//var source = new Subject<string>();	
		var subscription = Observable.Using(
			() => new EventLoopScheduler(),
			scheduler =>
			{
				return Observable.Create<string>((obs, ct) =>
				{
					var scheduleItem = scheduler.Schedule(0, (state,self) => {
						//Do work to get price (network request? or Heavy CPU work?)
						var price = state.ToString("c");
						LongRunningAction(price);
						obs.OnNext(price);
						//Without this check, we see that the Scheduler will try to 
						//	recursively call itself even when disposed.
						if(!ct.IsCancellationRequested)
							self(state+1);
					});
					return Task.FromResult(scheduleItem);
				});
			})
			.Subscribe();
	
		Thread.Sleep(TimeSpan.FromSeconds(1));
		subscription.Dispose(); // Scheduler is still busy!
		Console.ReadLine();
	}
	
	private static void LongRunningAction(string text)
	{
		Thread.Sleep(TimeSpan.FromSeconds(2));
		Console.WriteLine(text);
	}
