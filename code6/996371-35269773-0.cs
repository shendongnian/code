    internal static Task<List<T>> ToListAsync<T>(this IDbAsyncEnumerable<T> source, CancellationToken cancellationToken)
        {
          TaskCompletionSource<List<T>> tcs = new TaskCompletionSource<List<T>>();
          List<T> list = new List<T>();
          IDbAsyncEnumerableExtensions.ForEachAsync<T>(source, new Action<T>(list.Add), cancellationToken).ContinueWith((Action<Task>) (t =>
          {
            if (t.IsFaulted)
              tcs.TrySetException((IEnumerable<Exception>) t.Exception.InnerExceptions);
            else if (t.IsCanceled)
              tcs.TrySetCanceled();
            else
              tcs.TrySetResult(list);
          }), TaskContinuationOptions.ExecuteSynchronously);
          return tcs.Task;
        }
