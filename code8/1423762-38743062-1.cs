	var t3 = new Tester();
	IObservable<Tuple<int, int, int>> observable = Observable.FromEvent<Action<int, int, int>, Tuple<int, int, int>>(
		onNextHandler => (int i1, int i2, int i3) => onNextHandler(Tuple.Create(i1, i2, i3)),
		h => t3.ItHappened += h,
		h => t3.ItHappened -= h);
	using (var disposable = observable.Subscribe(t => Console.WriteLine($"{{{t.Item1}, {t.Item2}, {t.Item3}}}")))
    {
		t3.FireEvent(1, 2, 3);
	}
	t3.FireEvent(1, 2, 3);
