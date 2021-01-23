	public IConnectableObservable<int> ProcessOutput(IConnectableObservable<int> output)
	{
		var source = output.RefCount();
		return
			source
				.Merge(source.ToArray().Select(arr => arr.Sum()))
				.Publish();
	}
	
	void Main()
	{
		var output = Observable.Range(1, 10).Publish();
		
		var processed = ProcessOutput(output);
		
		processed.Subscribe(x => Console.WriteLine(x));
		
		processed.Connect();
	}
