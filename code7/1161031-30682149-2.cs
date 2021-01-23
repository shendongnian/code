    public static class Timeout
    {
        public static async Task<bool> ForAsync(Action operationWithTimeout, TimeSpan maxTime)
        {
            Task timeoutTask = Task.Delay(TimeSpan.FromSeconds(10));
            
            // This will await while any of both given tasks end.
            await Task.WhenAny(timeoutTask, Task.Factory.StartNew(operationWithTimeout));
            
            // Since timeoutTask was completed before wrapped File.Copy task you can 
            // consider that the operation timed out
            if(timeoutTask.Status == TaskStatus.RanToCompletion)
            {
                return Task.FromResult(false);
            }
            else
            {
                return Task.FromResult(true);
            }
        }
    }
