	var subscription = Observable.Create<IObservable<YourType>>(o =>
	{
		var current = groups.Replay();
		var connection = new SerialDisposable();
		connection.Disposable = current.Connect();
		return IsSubscribed
			.DistinctUntilChanged()
			.Select(isRunning =>
			{
				if (isRunning)
				{
					//Return the current replayed values.
					return current;
				}
				else
				{
					//Disconnect and replace current.
					current = source.Replay();
					connection.Disposable = current.Connect();
					//yield silence until the next time we resume.
					return Observable.Never<YourType>();
				}
			})
			.Subscribe(o);
	})
	.Switch()
	.Subscribe(o => Insert(o.Type, o.List));
