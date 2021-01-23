    public static void Match<T>(this TaskCompletionSource<T> tcs, Task<T> task)
    {
        task.ContinueWith(t =>
        {
            switch (t.Status)
            {
                case TaskStatus.Canceled:
                    tcs.SetCanceled();
                    break;
                case TaskStatus.Faulted:
                    tcs.SetException(t.Exception.InnerExceptions);
                    break;
                case TaskStatus.RanToCompletion:
                    tcs.SetResult(t.Result);
                    break;
            }
        });
    }
    public static void Match<T>(this TaskCompletionSource<T> tcs, Task task)
    {
        Match(tcs, task.ContinueWith(t => default(T)));
    }
