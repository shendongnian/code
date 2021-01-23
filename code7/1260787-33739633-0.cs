	void Main()
	{
		var pollingPeriod = TimeSpan.FromSeconds(5);
		var dbQueryTimeout = TimeSpan.FromSeconds(10);
		//You will want to have your Rx query timeout after the expected silence of the timer, and then further maximum silence.
		var rxQueryTimeOut = pollingPeriod + dbQueryTimeout;
		
		var scheduler = new EventLoopScheduler(ts => new Thread(ts) { Name = "DatabasePoller" });
		
		var query = Observable.Timer(pollingPeriod, scheduler)
						.SelectMany(_ => DatabaseQuery().ToObservable())
	                    .Timeout(rxQueryTimeOut, Observable.Return("Timeout"), scheduler)
						.Retry()	//Loop on errors
						.Repeat();	//Loop on success
	
		query.StartWith("Seed")
			.TimeInterval(scheduler)	//Just to debug, print the timing gaps.
			.Dump();
	}
	
	// Define other methods and classes here
	private static int delay = 9;
	private static int delayModifier = 1;
	public async Task<string> DatabaseQuery()
	{
		//Oscillate the delay between 3 and 12 seconds
		delay+=delayModifier;
		var timespan = TimeSpan.FromSeconds(delay);
		if(delay < 4 || delay > 11) delayModifier*=-1;
		timespan.Dump("delay");
		await Task.Delay(timespan);
		return "Value";
	}
