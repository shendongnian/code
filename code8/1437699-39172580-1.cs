	//var initialSource = Observable.FromEventPattern<FileSystemEventArgs>(fileWatcher, nameof(FileSystemWatcher.Created))
	//	.Merge(Observable.FromEventPattern<FileSystemEventArgs>(fileWatcher, nameof(FileSystemWatcher.Changed)));
	
        //Comment this out, and use the above lines for your code. This just makes testing the Rx components much easier.
	var initialSource = Observable.Interval(TimeSpan.FromSeconds(1)).Take(5)
		.Concat(Observable.Empty<long>().Delay(TimeSpan.FromSeconds(13)))
		.Concat(Observable.Interval(TimeSpan.FromSeconds(1)).Take(5));
	
	initialSource
		.Publish( _source => _source 
			.Buffer(_source
				.Scan(DateTimeOffset.MinValue, (lastPrimary, _) => DateTimeOffset.Now - lastPrimary > TimeSpan.FromSeconds(10) ? DateTimeOffset.Now : lastPrimary)
				.DistinctUntilChanged()
				.Delay(TimeSpan.FromSeconds(10))
			)
		)
		.Subscribe(list =>
		{
			Debug.WriteLine($"Time-stamp: {DateTime.Now.ToLongTimeString()}");
			Debug.WriteLine($"List Count: {list.Count}");
		});
