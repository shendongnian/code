    public static Task<T> Retry<T, TException>(Func<Task<T>> work, Action<TException> onException, TimeSpan retryInterval, int maxExecutionCount)
        where TException : Exception
    {
        int count = 0;
        bool haveResult = false;
        T result = default(T);
        Func<bool> condition = () => count < maxExecutionCount;
        Func<Task> body =
            () =>
            {
                Task t1 = count > 0 ? DelayedTask.Delay(retryInterval) : CompletedTask.Default;
                Task t2 =
                    t1.Then(
                        _ =>
                        {
                            count++;
                            return work();
                        })
                    .Select(
                        task =>
                        {
                            result = task.Result;
                            haveResult = true;
                        });
                Task t3 =
                    t2.Catch<TException>(
                        (_, ex) =>
                        {
                            onException(ex);
                        })
                    .Catch<Exception>((_, ex) =>
                        {
                            throw new RetryWrapperException("Unexpected exception occurred", ex);
                        });
                return t3;
            };
        Func<Task, T> selector =
            _ =>
            {
                if (haveResult)
                    return result;
                string message = string.Format("Retry unsuccessful after: {0} attempt(s)", maxExecutionCount);
                throw new RetryWrapperException(message);
            };
        return
            TaskBlocks.While(condition, body)
            .Select(selector);
    }
