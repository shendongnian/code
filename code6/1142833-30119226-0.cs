	var signal = new Subject<Unit>();
	var observableSequence =
		File
			.ReadAllLines(FileName)
			.ToObservable(Scheduler.Default)
			.TakeUntil(signal);
	var count = 0;
	observableSequence.Subscribe(u=>
	{
		if (++count == 100) 
		{
			signal.OnNext(Unit.Default);
		}
	}, () => Console.WriteLine(count));
	
	Console.WriteLine(count);
