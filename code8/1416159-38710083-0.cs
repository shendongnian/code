	var collection = new ObservableCollection<int>();
	
	var query =
		Observable
			.FromEventPattern<
				NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
				h => collection.CollectionChanged += h, h => collection.CollectionChanged -= h)
			.Select(ep => collection.Count == 10)
			.Where(x => x)
			.Take(1)
			.Timeout(TimeSpan.FromSeconds(10.0), Observable.Return(false));
	query.Subscribe(flag =>
	{
		if (flag) // capacity
		{
		}
		else //timeout
		{
		}
	});
