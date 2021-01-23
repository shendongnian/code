	static class Extensions
	{
		struct Unit { }
		public static IAsyncResult Apmize<T>(this Task<T> @this, AsyncCallback callback, object state)
		{
			return @this.ApmizeInternal<T>(callback, state);
		}
		public static IAsyncResult Apmize(this Task @this, AsyncCallback callback, object state)
		{
			return @this.ApmizeInternal<Unit>(callback, state);
		}
		private static IAsyncResult ApmizeInternal<T>(this Task @this, AsyncCallback callback, object state)
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
						else
						{
							if (t is Task<T>) 
							{
								tcs.TrySetResult(((Task<T>)t).Result);
							}
							else
							{
								tcs.TrySetResult(default(T));
							}
						}
						if (callback != null) callback(tcs.Task);
					},
					CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default
				);
			return tcs.Task;
		}
	}
