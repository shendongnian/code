	public static Task<List<T>> ToListAsync<T>(this IDbAsyncEnumerable<T> source, CancellationToken cancellationToken)
	{
		TaskCompletionSource<List<T>> tcs = new TaskCompletionSource<List<T>>();
		List<T> list = new List<T>();
		ForEachAsync<T>(source.GetAsyncEnumerator(), new Action<T>(list.Add), cancellationToken).ContinueWith((Action<Task>)(t =>
		{
			if (t.IsFaulted)
				tcs.TrySetException((IEnumerable<Exception>)t.Exception.InnerExceptions);
			else if (t.IsCanceled)
				tcs.TrySetCanceled();
			else
				tcs.TrySetResult(list);
		}), TaskContinuationOptions.ExecuteSynchronously);
		return tcs.Task;
	}
	private static async Task ForEachAsync<T>(IDbAsyncEnumerator<T> enumerator, Action<T> action, CancellationToken cancellationToken)
	{
		using (enumerator)
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (await System.Data.Entity.Utilities.TaskExtensions.WithCurrentCulture<bool>(enumerator.MoveNextAsync(cancellationToken)))
			{
				Task<bool> moveNextTask;
				do
				{
					cancellationToken.ThrowIfCancellationRequested();
					T current = enumerator.Current;
					moveNextTask = enumerator.MoveNextAsync(cancellationToken);
					action(current);
				}
				while (await System.Data.Entity.Utilities.TaskExtensions.WithCurrentCulture<bool>(moveNextTask));
			}
		}
	}
