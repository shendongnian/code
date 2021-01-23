    private void NotifyCancellation(bool throwOnFirstException)
    {
        // fast-path test to check if Notify has been called previously
        if (IsCancellationRequested)
            return;
 
        // If we're the first to signal cancellation, do the main extra work.
        if (Interlocked.CompareExchange(ref m_state, NOTIFYING, NOT_CANCELED) == NOT_CANCELED)
        {
            // Dispose of the timer, if any
            Timer timer = m_timer;
            if(timer != null) timer.Dispose();
 
            //record the threadID being used for running the callbacks.
            ThreadIDExecutingCallbacks = Thread.CurrentThread.ManagedThreadId;
            
            //If the kernel event is null at this point, it will be set during lazy construction.
            if (m_kernelEvent != null)
                m_kernelEvent.Set(); // update the MRE value.
 
            // - late enlisters to the Canceled event will have their callbacks called immediately in the Register() methods.
            // - Callbacks are not called inside a lock.
            // - After transition, no more delegates will be added to the 
            // - list of handlers, and hence it can be consumed and cleared at leisure by ExecuteCallbackHandlers.
            ExecuteCallbackHandlers(throwOnFirstException);
            Contract.Assert(IsCancellationCompleted, "Expected cancellation to have finished");
        }
    }
