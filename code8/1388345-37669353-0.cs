	IDictionary<string, BlockingCollection<object>> uploadQueues = new Dictionary<string, BlockingCollection<Object>>();
	public IObservable<object> ListenToQueueEvents(string workspaceId)
	{
		//Not sure what the return value is here, using `Object` as a place holder.
		//	Note that we are using an overload that takes a `CancellationToken`
		return Observable.Create<object>((obs, ct) =>
		{
			var els = new EventLoopScheduler(ts => new Thread(ts)
			{
				IsBackground = true,//? or false? Should it stop the process from terminating if it still running?
				Name = $"{workspaceId}Processor"
			});
			var subscription = uploadQueues[workspaceId] //BlockingCollection<FileEvent>>
	   			.GetConsumingEnumerable(ct)	//Allow cancellation while wating for next item
	   			.ToObservable(els)	//Serialise onto a single thread.
	   			.Select(evt=>TheAsyncThingIWasDoingInTheSubscribe(evt).ToObservable())
				.Concat()
	   			.Subscribe(obs);
			//You could try to dispose of the els (EventLoopScheduler), But I have had issues doing so in the past. 
			//	Leaving as Background should allow it to die (but non deterministically) :-(
			return Task.FromResult(subscription);
		});
	}
	private static Task<object> TheAsyncThingIWasDoingInTheSubscribe(object evt)
	{
		//The return of the async thing you were doing in the subscribe
		return Task.FromResult(new Object());
	}
