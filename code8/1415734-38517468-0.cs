	IObservable<EventPattern<StudentAdmittedEventArgs>[]> observable =
		admissionObservable
			.Publish(pxs =>
				pxs
					.Window(pxs, x => Observable.Timer(timeSpan))
					.Select(ys => ys.Take(2)))
			.SelectMany(ys => ys.ToArray())
			.Where(ys => ys.Skip(1).Any());
