	public static IObservable<IList<TSource>> BufferWithThrottle<TSource>(this IObservable<TSource> source, int maxAmount, TimeSpan threshold)
	{
		return Observable.Create<IList<TSource>>((obs) =>
		{
			return source.GroupByUntil(_ => true,
									   g => g.Throttle(threshold).Select(_ => Unit.Default)
											 .Merge(g.Take(maxAmount)
											 		 .LastAsync()
													 .Select(_ => Unit.Default)))
						 .SelectMany(i => i.ToList())
						 .Subscribe(obs);
		});
	}
