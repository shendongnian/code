	public IEnumerable<IObservable<Thing>> GetThingsObs()
	{
		var rnd = new Random();
		return Enumerable.Range(0, 3).Select(_ => {
			return Observable.Create<Thing>(obs =>
			{
				var things = Enumerable.Range(0, 3).Select(i => new Thing() 
				{ 
					Markets = Enumerable.Range(0, 3).Select<int, Market>(x => 
					{					
						return new Market()
						{
							Prices = new Price
							{
								AvailableToBuy = Enumerable.Range(0, 3)
									.Select(y => new AvailablePrice { Id = string.Format("{0}:{1}:{2}", i, x, y), Size = rnd.Next(0, 10), Price = rnd.Next(0, 20) })
									.ToList()
							}
						};
					}).ToList()
				});
				foreach(var thing in things)
					obs.OnNext(thing);
                // this bit is important, but I'll get back to it later
				obs.OnCompleted();
				return Disposable.Empty;
			});
		});
	}
