    public static class WaitHandleExtensions
    {
        public static Task WaitOneAsync(this WaitHandle waitHandle, CancellationToken cancellationToken)
        {    
            return WaitOneAsync(waitHandle, Timeout.Infinite, cancellationToken);
        }
    
                public static async Task<bool> WaitOneAsync(this WaitHandle waitHandle, int timeout, CancellationToken cancellationToken)
        {    
            // A Mutex can't use RegisterWaitForSingleObject as a Mutex requires the wait and release to be on the same thread
            // but RegisterWaitForSingleObject acquires the Mutex on a ThreadPool thread.
            if (waitHandle is Mutex)
                throw new ArgumentException(StringResources.MutexMayNotBeUsedWithWaitOneAsyncAsThreadIdentityIsEnforced, nameof(waitHandle));
    
            cancellationToken.ThrowIfCancellationRequested();
    
            var tcs = new TaskCompletionSource<bool>();
            var rwh = ThreadPool.RegisterWaitForSingleObject(waitHandle, OnWaitOrTimerCallback, tcs, timeout, true);
            Contract.Assume(rwh != null);
    
            var cancellationCallback = BuildCancellationCallback(rwh, tcs);
    
            using (cancellationToken.Register(cancellationCallback))
            {
                try
                {
                    return await tcs.Task.ConfigureAwait(false);
                }
                finally
                {
                    rwh.Unregister(null);
                }
            }
        }
    
        private static Action BuildCancellationCallback(RegisteredWaitHandle rwh, TaskCompletionSource<bool> tcs)
        {    
            return () =>
            {
                if (rwh.Unregister(null))
                {
                    tcs.SetCanceled();
                }
            };
        }
    
        private static void OnWaitOrTimerCallback(object state, bool timedOut)
        {    
            var taskCompletionSource = (TaskCompletionSource<bool>)state;
    
            taskCompletionSource.SetResult(!timedOut);
        }
    }
