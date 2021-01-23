    public static class MapperExtensions
    {
        public static Task<TResult> MapAsync<TSource, TResult>(this IMapper mapper, Task<TSource> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var tcs = new TaskCompletionSource<TResult>();
            task
                .ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task
                .ContinueWith
                (
                    t =>
                    {
                        tcs.TrySetResult(mapper.Map<TSource, TResult>(t.Result));
                    },
                    TaskContinuationOptions.OnlyOnRanToCompletion
                );
            task
                .ContinueWith
                (
                    t => tcs.TrySetException(t.Exception),
                    TaskContinuationOptions.OnlyOnFaulted
                );
            return tcs.Task;
        }
    }
