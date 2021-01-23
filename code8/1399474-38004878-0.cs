	Console.WriteLine("Starting on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
	var are = new AutoResetEvent(false);
	using (var subject = new Subject<int>())
	{
		using (
			subject
				.ObserveOn(TaskPoolScheduler.Default)
				.Subscribe(o =>
				{
					Console.WriteLine("Received {1} on threadId:{0}", Thread.CurrentThread.ManagedThreadId, o);
					Task.Delay(1000 * o);
				}, () =>
				{
					Console.WriteLine("OnCompleted on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
					are.Set();
				}))
			{
				subject.OnNext(3);
				subject.OnNext(2);
				subject.OnNext(1);
				subject.OnCompleted();
				are.WaitOne();
			}
	}
	Console.WriteLine("Done.");
