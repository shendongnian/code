	public static IObservable<C> MergeOrCombineLatest<A, B, C>(
		this IObservable<A> a,
		IObservable<B> b,
		Func<A, C> aResultSelector, // When A starts before B
		Func<B, C> bResultSelector, // When B starts before A
		Func<A, B, C> bothResultSelector) // When both A and B have started
	{
		return
			a.Publish(aa =>
				b.Publish(bb =>
					aa.CombineLatest(bb, bothResultSelector).Publish(xs =>
						aa
							.Select(aResultSelector)
							.Merge(bb.Select(bResultSelector))
							.TakeUntil(xs)
							.SkipLast(1)
							.Merge(xs))));
	}
