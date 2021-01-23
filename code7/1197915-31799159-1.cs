    public IObservable<Progress<Output>> Calculate(IEnumerable<Inputs> inputs)
	{
		return
			Observable
				.Create<Progress<Output>>(o =>
				{
					var source = inputs.ToArray();
					var total = source.Length;
					return
						source
							.ToObservable()
							.Select((x, n) =>
								new Progress<Output>(LongRunningCalculation(x), n, total))
							.Subscribe(o);
				});		
	}
