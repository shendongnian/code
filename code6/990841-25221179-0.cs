    public static async Task<T> Retry<T, TException>(Func<T> work, Action<TException> onException, TimeSpan retryInterval, int maxExecutionCount = 3) where TException : Exception
    {
        for (var i = 0; i < maxExecutionCount; i++)
        {
            try
            {
                return await Task.Factory.StartNew(work);
            } catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is TException)
                    {
                        // allow program to continue in this case
                        // do necessary logging or whatever
                        if (onException != null) { onException((TException)e); }
    
                        Thread.Sleep(retryInterval);
                        return true;
                    }
                    throw new RetryWrapperException("Unexpected exception occurred", ae);
                });
            }
        }
        var msg = "Retry unsuccessful after: {0} attempt(s)".FormatWith(maxExecutionCount);
        throw new RetryWrapperException(msg);
    }
