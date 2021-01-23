    public sealed class AsyncMonitor
    {
        private PulseAwaitable _currentWaiter;
        public AsyncMonitor()
        {
            _currentWaiter = new PulseAwaitable();
        }
        public void Pulse()
        {
            // Optimize for the case when calling Pulse() when nobody is waiting.
            //
            // This has an inherent race condition when calling Pulse() and Wait()
            // at the same time. The question this was written for did not specify
            // how to resolve this, so it is a valid answer to tolerate either
            // result and just allow the race condition.
            //
            if (_currentWaiter.HasWaitingContinuations)
                Interlocked.Exchange(ref _currentWaiter, new PulseAwaitable()).Complete();
        }
        public PulseAwaitable Wait()
        {
            return _currentWaiter;
        }
    }
    // This class maintains a list of waiting continuations to be executed when
    // the owning AsyncMonitor is pulsed.
    public sealed class PulseAwaitable : INotifyCompletion
    {
        // List of pending 'await' delegates.
        private Action _pendingContinuations;
        // Flag whether we have been pulsed. This is the primary variable
        // around which we build the lock free synchronization.
        private int _pulsed;
        // AsyncMonitor creates instances as required.
        internal PulseAwaitable()
        {
        }
        // This check has a race condition which is tolerated.
        // It is used to optimize for cases when the PulseAwaitable has no waiters.
        internal bool HasWaitingContinuations
        {
            get { return Volatile.Read(ref _pendingContinuations) != null; }
        }
        // Called by the AsyncMonitor when it is pulsed.
        internal void Complete()
        {
            // Set pulsed flag first because that is the variable around which
            // we build the lock free protocol. Everything else this method does
            // is free to have race conditions.
            Interlocked.Exchange(ref _pulsed, 1);
            // Execute pending continuations. This is free to race with calls
            // of OnCompleted seeing the pulsed flag first.
            Interlocked.Exchange(ref _pendingContinuations, null)?.Invoke();
        }
        #region Awaitable
        // There is no need to separate the awaiter from the awaitable
        // so we use one class to implement both parts of the protocol.
        public PulseAwaitable GetAwaiter()
        {
            return this;
        }
        #endregion
        #region Awaiter
        public bool IsCompleted
        {
            // The return value of this property does not need to be up to date so we could omit the 'Volatile.Read' if we wanted to.
            // What is not allowed is returning "true" even if we are not completed, but this cannot happen since we never transist back to incompleted.
            get { return Volatile.Read(ref _pulsed) == 1; }
        }
        public void OnCompleted(Action continuation)
        {
            // Protected against manual invocations. The compiler-generated code never passes null so you can remove this check in release builds if you want to.
            if (continuation == null)
                throw new ArgumentNullException(nameof(continuation));
            // Standard pattern of maintaining a lock free immutable variable: read-modify-write cycle.
            // See for example here: https://blogs.msdn.microsoft.com/oldnewthing/20140516-00/?p=973
            // Again the 'Volatile.Read' is not really needed since outdated values will be detected at the first iteration.
            var oldContinuations = Volatile.Read(ref _pendingContinuations);
            for (;;)
            {
                var newContinuations = (oldContinuations + continuation);
                var actualContinuations = Interlocked.CompareExchange(ref _pendingContinuations, newContinuations, oldContinuations);
                if (actualContinuations == oldContinuations)
                    break;
                oldContinuations = actualContinuations;
            }
            // Now comes the interesting part where the actual lock free synchronization happens.
            // If we are completed then somebody needs to clean up remaining continuations.
            // This happens last so the first part of the method can race with pulsing us.
            if (IsCompleted)
                Interlocked.Exchange(ref _pendingContinuations, null)?.Invoke();
        }
        public void GetResult()
        {
            // This is just to check against manual calls. The compiler will never call this when IsCompleted is false.
            // (Assuming your OnCompleted implementation is bug-free and you don't execute continuations before IsCompleted becomes true.)
            if (!IsCompleted)
                throw new NotSupportedException("Synchronous waits are not supported. Use 'await' or OnCompleted to wait asynchronously");
        }
        #endregion
    }
