    class RateLimitedWrapper<TException> where TException : Exception
    {
        private readonly AsyncAutoResetEvent autoResetEvent = new AsyncAutoResetEvent(set: true);
    
        public async Task<T> Execute<T>(Func<Task<T>> func) 
        {
            while (true)
            {
                try
                {
                    await autoResetEvent.WaitAsync();
    
                    var result = await func();
    
                    autoResetEvent.Set();
    
                    return result;
                }
                catch (TException)
                {
                    var ignored = Task.Delay(500).ContinueWith(_ => autoResetEvent.Set());
                }
            }
        }
    }
