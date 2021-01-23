    public async Task<T> Retry<T, TException>(Func<Task<T>> work, Action<TException> onException, TimeSpan retryInterval, int maxExecutionCount)
        where TException : Exception
    {
        int count = 0;
        while (count < maxExecutionCount)
        {
            if (count > 0)
                await Task.Delay(retryInterval);
            count++;
            try
            {
                return await work();
            }
            catch (TException ex)
            {
                onException(ex);
            }
            catch (Exception ex)
            {
                throw new RetryWrapperException("Unexpected exception occurred", ex);
            }
        }
        string message = string.Format("Retry unsuccessful after: {0} attempt(s)", maxExecutionCount);
        throw new RetryWrapperException(message);
    }
