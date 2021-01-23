	public static Task<T> Apmize<T>(this Task<T> @this, AsyncCallback callback, object state)
	{
		if (@this.AsyncState == state)
			return @this.ContinueWith(t => callback(t));
		var tcs = new TaskCompletionSource<T>(state);
		@this.ContinueWith
			(
				t =>
				{
					if (task.IsFaulted) tcs.TrySetException(task.Exception.InnerExceptions);
					else if (task.IsCanceled) tcs.TrySetCanceled(); 
					else tcs.TrySetResult(task.Result);
					if (callback != null) callback(tcs.Task);
				},
				CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default
			);
		return tcs.Task;
	}
