	private IDisposable AddHandlers()
	{
		var tpns = // IObservable<{anonymous}>
			from t in Tasks.ToObservable()
			from ep in Observable.FromEventPattern<
					PropertyChangedEventHandler, PropertyChangedEventArgs>(
				h => t.PropertyChanged += h,
				h => t.PropertyChanged -= h)
			select new { Task = t, ep.EventArgs.PropertyName };
	
		IObservable<Task> statusChanges =
			from tpn in tpns
			where tpn.PropertyName == "Status"
			select tpn.Task;
	
		IObservable<Task> timeChanges =
			from tpn in tpns
			where tpn.PropertyName == "Time"
			select tpn.Task;
	
		IDisposable statusSubscription =
			statusChanges
				.Subscribe(task => UpdateStepStatusFromTasks());
	
		IDisposable timeSubscription =
			timeChanges
				.Subscribe(task => UpdateStepTimesFromTasks());
	
		return new CompositeDisposable(statusSubscription, timeSubscription);
	}
