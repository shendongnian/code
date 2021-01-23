    public static class AsyncExtensions
    {
        public static Task<T> WithTimeout<T>(this Task<T> task, TimeSpan timeout)
        {
            return Task.Factory.StartNew(() =>
            {
                var b = task.Wait((int)timeout.TotalMilliseconds);
                if (b) return task.Result;
                throw new WebException("The operation has timed out", WebExceptionStatus.Timeout);
            });
        }
    }
