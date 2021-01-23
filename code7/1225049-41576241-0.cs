        public static Task<TReturn> Convert<T, TReturn>(this Task<T> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            var tcs = new TaskCompletionSource<TReturn>();
            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t =>
            {
                tcs.TrySetResult(Mapper.Map<T, TReturn>(t.Result));
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            return tcs.Task;
        }
        public static Task<List<TReturn>> ConvertEach<T, TReturn>(this Task<List<T>> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            var tcs = new TaskCompletionSource<List<TReturn>>();
            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t =>
            {
                tcs.TrySetResult(t.Result.Select(Mapper.Map<T, TReturn>).ToList());
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            return tcs.Task;
        }
