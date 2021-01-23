    public static Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks)
    {
        TaskCompletionSource<TResult[]> taskCompletionSource = new TaskCompletionSource<TResult[]>();
        Action<Task<TResult>[]> continuationAction =
            completedTasks =>
            {
                List<TResult> results = new List<TResult>();
                List<Exception> exceptions = new List<Exception>();
                bool canceled = false;
                foreach (var completedTask in completedTasks)
                {
                    switch (completedTask.Status)
                    {
                    case TaskStatus.RanToCompletion:
                        results.Add(completedTask.Result);
                        break;
                    case TaskStatus.Canceled:
                        canceled = true;
                        break;
                    case TaskStatus.Faulted:
                        exceptions.AddRange(completedTask.Exception.InnerExceptions);
                        break;
                    default:
                        throw new InvalidOperationException("Unreachable");
                    }
                }
                if (exceptions.Count > 0)
                    taskCompletionSource.SetException(exceptions);
                else if (canceled)
                    taskCompletionSource.SetCanceled();
                else
                    taskCompletionSource.SetResult(results.ToArray());
            };
        Task.Factory.ContinueWhenAll(tasks.ToArray(), continuationAction);
        return taskCompletionSource.Task;
    }
