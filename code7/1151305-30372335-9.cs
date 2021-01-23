	public static IAsyncResult Apmize<T>(this Task<T> @this, AsyncCallback callback, object state)
	{
		if (@this.AsyncState == state)
			return @this.ContinueWith(t => callback(t));
		var tcs = new TaskCompletionSource<T>(state);
		@this.ContinueWith
			(
				t =>
				{
					if (t.IsFaulted) tcs.TrySetException(t.Exception.InnerExceptions);
					else if (t.IsCanceled) tcs.TrySetCanceled(); 
					else tcs.TrySetResult(t.Result);
					if (callback != null) callback(tcs.Task);
				},
				CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default
			);
		return tcs.Task;
	}
