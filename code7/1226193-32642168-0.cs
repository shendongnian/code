	public static IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector)
	{
		if (condition == null)
			throw new ArgumentNullException("condition");
		if (iterate == null)
			throw new ArgumentNullException("iterate");
		if (resultSelector == null)
			throw new ArgumentNullException("resultSelector");
		return Observable.s_impl.Generate<TState, TResult>(initialState, condition, iterate, resultSelector);
	}
	
	public virtual IObservable<TResult> Generate<TState, TResult>(TState initialState, Func<TState, bool> condition, Func<TState, TState> iterate, Func<TState, TResult> resultSelector)
	{
		return (IObservable<TResult>)new Generate<TState, TResult>(initialState, condition, iterate, resultSelector, SchedulerDefaults.Iteration);
	}
	
	internal static IScheduler Iteration
	{
		get
		{
			return (IScheduler)CurrentThreadScheduler.Instance;
		}
	}
