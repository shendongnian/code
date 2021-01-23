    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
	task.RunInBackground().ContinueWith(t =>
	{
		throw t.Exception;
	},
		CancellationToken.None,
		TaskContinuationOptions.OnlyOnFaulted,
		TaskScheduler.FromCurrentSynchronizationContext()
	).ConfigureAwait(false);
