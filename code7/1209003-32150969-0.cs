	private IObservable<IList<Timestamped<Entity>>> GetStream()
	{
		return
			Observable
				.Create<IList<Timestamped<Entity>>>(o =>
					GetSomeLongRunningSubscriptionStream()
						.Timestamp()
						.Scan(
							new Dictionary<string, Timestamped<Entity>>(),
							(accumulator, update) =>
							{
								accumulator[update.Value.ID] = update;
								return accumulator;
							})
						.Select(x => x.Select(y => y.Value).ToList())
						.Replay(1)
						.RefCount()
						.Subscribe(o));
	}
