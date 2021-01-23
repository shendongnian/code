    public static class WaitHandleEx
    {
        public static Task ToTask(this WaitHandle waitHandle)
        {
            var tcs = new TaskCompletionSource<object>();
    
            // Registering callback to wait till WaitHandle changes its state
    
            ThreadPool.RegisterWaitForSingleObject(
                waitObject: waitHandle,
                callBack:(o, timeout) => { tcs.SetResult(null); }, 
                state: null, 
                timeout: TimeSpan.MaxValue, 
                executeOnlyOnce: true);
    
            return tcs.Task;
        }
    }
