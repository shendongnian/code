	public static class TaskExt
	{
		// flowing Thread.CurrentPrincipal
		public static FlowingAwaitable<TResult, IPrincipal> RunAndFlowPrincipal<TResult>(
			Func<TResult> func,
			CancellationToken token = default(CancellationToken))
		{
			return RunAndFlow(
				func,
				() => Thread.CurrentPrincipal, 
				s => Thread.CurrentPrincipal = s,
				token);
		}
		// flowing anything
		public static FlowingAwaitable<TResult, TState> RunAndFlow<TResult, TState>(
			Func<TResult> func,
			Func<TState> saveState, 
			Action<TState> restoreState,
			CancellationToken token = default(CancellationToken))
		{
			// wrap func with func2 to capture and propagate exceptions
			Func<Tuple<Func<TResult>, TState>> func2 = () =>
			{
				Func<TResult> getResult;
				try
				{
					var result = func();
					getResult = () => result;
				}
				catch (Exception ex)
				{
					// capture the exception
					var edi = ExceptionDispatchInfo.Capture(ex);
					getResult = () => 
					{ 
						edi.Throw(); 
						// should never be reaching this point, 
						// but without the compiler whats us to 
						// return a dummy TResult value here
						throw new AggregateException(edi.SourceException);
					}; 
				}
				return new Tuple<Func<TResult>, TState>(getResult, saveState());	
			};
			return new FlowingAwaitable<TResult, TState>(
				Task.Run(func2, token), restoreState);
		}
		public class FlowingAwaitable<TResult, TState> :
			System.Runtime.CompilerServices.ICriticalNotifyCompletion
		{
			readonly System.Runtime.CompilerServices.TaskAwaiter<Tuple<Func<TResult>, TState>> _awaiter;
			readonly Action<TState> _restoreState;
			public FlowingAwaitable(Task<Tuple<Func<TResult>, TState>> task, Action<TState> restoreState)
			{
				_awaiter = task.GetAwaiter();
				_restoreState = restoreState;
			}
			public FlowingAwaitable<TResult, TState> GetAwaiter()
			{
				return this;
			}
			public bool IsCompleted
			{
				get { return _awaiter.IsCompleted; }
			}
			public TResult GetResult()
			{
				var result = _awaiter.GetResult();
				_restoreState(result.Item2);
				return result.Item1();
			}
			public void OnCompleted(Action continuation)
			{
				_awaiter.OnCompleted(continuation);
			}
			public void UnsafeOnCompleted(Action continuation)
			{
				_awaiter.UnsafeOnCompleted(continuation);
			}
		}
	}
