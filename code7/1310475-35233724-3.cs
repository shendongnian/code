    public class AsyncManualResetEvent
    {
        private volatile CompletionWrapper _completionWrapper = new CompletionWrapper();
        public Task WaitAsync()
        {
            var wrapper = _completionWrapper;
            wrapper.WaitAsyncCalled = true;
            return wrapper.Tcs.Task;
        }
        public bool WaitAsyncCalled
        {
            get { return _completionWrapper.WaitAsyncCalled; }
        }
        public void Set() {
            _completionWrapper.Tcs.TrySetResult(true); }
        public void Reset()
        {
            while (true)
            {
                var wrapper = _completionWrapper;
                if (!wrapper.Tcs.Task.IsCompleted ||
                    Interlocked.CompareExchange(ref _completionWrapper, new CompletionWrapper(), wrapper) == wrapper)
                    return;
            }
        }
        private class CompletionWrapper
        {
            public TaskCompletionSource<bool> Tcs { get; } = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            public bool WaitAsyncCalled { get; set; }
        }
    }
