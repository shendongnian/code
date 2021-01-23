    public sealed class AsyncMonitor
    {
        public struct Awaitable : INotifyCompletion
        {
            // We use a struct to avoid allocations. Note that this means the compiler will copy
            // the struct around in the calling code when doing 'await', so for your own debugging
            // sanity make all variables readonly.
            private readonly AsyncMonitor _monitor;
            private readonly int _iteration;
            public Awaitable(AsyncMonitor monitor)
            {
                lock (monitor)
                {
                    _monitor = monitor;
                    _iteration = monitor._iteration;
                }
            }
            public Awaitable GetAwaiter()
            {
                return this;
            }
            public bool IsCompleted
            {
                get
                {
                    // We use the iteration counter as an indicator when we should be complete.
                    lock (_monitor)
                    {
                        return _monitor._iteration != _iteration;
                    }
                }
            }
            public void OnCompleted(Action continuation)
            {
                lock (_monitor)
                {
                    // Not calling IsCompleted since we already have a lock.
                    if (_monitor._iteration != _iteration)
                    {
                        continuation();
                    }
                    else
                    {
                        _monitor._waiting += continuation;
                    }
                }
            }
            public void GetResult()
            {
                lock (_monitor)
                {
                    // Not calling IsCompleted since we already have a lock.
                    if (_monitor._iteration == _iteration)
                        throw new NotSupportedException("Synchronous wait is not supported. Use await or OnCompleted.");
                }
            }
        }
        private Action _waiting;
        private int _iteration;
        public AsyncMonitor()
        {
        }
        public void Pulse()
        {
            Action execute = null;
            lock (this)
            {
                // If nobody is waiting we don't need to increment the iteration counter.
                if (_waiting != null)
                {
                    _iteration++;
                    execute = _waiting;
                    _waiting = null;
                }
            }
            execute?.Invoke();
        }
        public Awaitable Wait()
        {
            return new Awaitable(this);
        }
    }
