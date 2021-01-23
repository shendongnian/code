	public static IObservable<IList<T>> MergeCombineLatest<T>(this IObservable<IObservable<T>> outer, bool removeCompleted)
	{
		return outer
			.SelectMany((inner, i) => inner
				.Materialize()
				.SelectMany(nt => nt.Kind == NotificationKind.OnNext
					? Observable.Return(Tuple.Create(i, nt.Value, true))
					: nt.Kind == NotificationKind.OnCompleted
						? removeCompleted
							? Observable.Return(Tuple.Create(i, default(T), false))
							: Observable.Empty<Tuple<int, T, bool>>()
						: Observable.Throw<Tuple<int, T, bool>>(nt.Exception)
				)
			)
			.Scan(ImmutableDictionary<int, T>.Empty, (dict, t) => t.Item3 ? dict.SetItem(t.Item1, t.Item2) : dict.Remove(t.Item1))
			.Select(dict => dict.Values.ToList());
	}
