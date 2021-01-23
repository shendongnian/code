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
                // The compiler never passes null, but someone may call it manually.
                if (continuation == null)
                    throw new ArgumentNullException(nameof(continuation));
                lock (_monitor)
                {
                    // Not calling IsCompleted since we already have a lock.
                    if (_monitor._iteration == _iteration)
                    {
                        _monitor._waiting += continuation;
                        // null the continuation to indicate the following code
                        // that we completed and don't want it executed.
                        continuation = null;
                    }
                }
                // If we were already completed then we didn't null the continuation.
                // (We should invoke the continuation outside of the lock because it
                // may want to Wait/Pulse again and we want to avoid reentrancy issues.)
                continuation?.Invoke();
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
            // Important: execute the callbacks outside the lock because they might Pulse or Wait again.
            execute?.Invoke();
        }
        public Awaitable Wait()
        {
            return new Awaitable(this);
        }
    }
