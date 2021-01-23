    public class AsyncManualResetEvent
    {
        private volatile Completion _completion = new Completion();
        public bool HasWaiters => _completion.GetAwaiter().HasWaiters;
        public Completion WaitAsync()
        {
            return _completion;
        }
        public void Set()
        {
            _completion.Set();
        }
        public void Reset()
        {
            while (true)
            {
                var completion = _completion;
                if (!completion.IsCompleted ||
                    Interlocked.CompareExchange(ref _completion, new Completion(), completion) == completion)
                    return;
            }
        }
    }
    public class Completion
    {
        private readonly TaskCompletionSource<bool> m_tcs;
        private readonly CompletionAwaiter _awaiter;
        public Completion()
        {
            m_tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            _awaiter = new CompletionAwaiter(m_tcs.Task);
        }
        public CompletionAwaiter GetAwaiter() => _awaiter;
        public bool IsCompleted => _awaiter.IsCompleted;
        public void Set()
        {
            m_tcs.TrySetResult(true);
        }
    }
    public class CompletionAwaiter : ICriticalNotifyCompletion
    {
        private readonly TaskAwaiter _taskAwaiter;
        internal CompletionAwaiter(Task task)
        {
            _taskAwaiter = task.GetAwaiter();
            HasWaiters = false;
        }
        public bool HasWaiters { get; private set; }
        public bool IsCompleted => _taskAwaiter.IsCompleted;
        public void GetResult() => _taskAwaiter.GetResult();
        public void OnCompleted(Action continuation)
        {
            HasWaiters = true;
            _taskAwaiter.OnCompleted(continuation);
        }
        public void UnsafeOnCompleted(Action continuation)
        {
            HasWaiters = true;
            _taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }
