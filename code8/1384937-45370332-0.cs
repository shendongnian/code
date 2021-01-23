    public static class AsyncExtensions
    {
        public static Task<T> GetFirstSuccessfulTask<T>(this IReadOnlyCollection<Task<T>> tasks)
        {
            var tcs = new TaskCompletionSource<T>();
            int remainingTasks = tasks.Count;
            foreach (var task in tasks)
            {
                task.ContinueWith(t =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                        tcs.TrySetResult(t.Result);
                    else if (Interlocked.Decrement(ref remainingTasks) == 0)
                        tcs.SetException(new AggregateException(
                            tasks.SelectMany(t2 => t2.Exception?.InnerExceptions ?? Enumerable.Empty<Exception>())));
                });
            }
            return tcs.Task;
        }
    }
