    public class AsyncManualResetEvent
    {
        private volatile Completion _completion = new Completion();
        public bool HasWaiters => _completion.HasWaiters;
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
        private readonly TaskCompletionSource<bool> _tcs;
        private readonly CompletionAwaiter _awaiter;
        public Completion()
        {
            _tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            _awaiter = new CompletionAwaiter(_tcs.Task, this);
        }
        public CompletionAwaiter GetAwaiter() => _awaiter;
        public bool IsCompleted => _tcs.Task.IsCompleted;
        public bool HasWaiters { get; private set; }
        public void Set() => _tcs.TrySetResult(true);
        public struct CompletionAwaiter : ICriticalNotifyCompletion
        {
            private readonly TaskAwaiter _taskAwaiter;
            private readonly Completion _parent;
            internal CompletionAwaiter(Task task, Completion parent)
            {
                _parent = parent;
                _taskAwaiter = task.GetAwaiter();
            }
            public bool IsCompleted => _taskAwaiter.IsCompleted;
            public void GetResult() => _taskAwaiter.GetResult();
            public void OnCompleted(Action continuation)
            {
                _parent.HasWaiters = true;
                _taskAwaiter.OnCompleted(continuation);
            }
            public void UnsafeOnCompleted(Action continuation)
            {
                _parent.HasWaiters = true;
                _taskAwaiter.UnsafeOnCompleted(continuation);
            }
        }
    }
