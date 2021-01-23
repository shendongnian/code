	public void DoWorkInParallel(CustomCollectionClass collection)
	{
		var query =
			from x in collection.ToObservable()
			from r in Observable.FromAsync(() => DoWorkOnItemInCollection(x))
			select x;
			
		query.Subscribe(x => { }, ex => { }, async () =>
		{
			await SaveModifedCollection(collection);
		});
	}
