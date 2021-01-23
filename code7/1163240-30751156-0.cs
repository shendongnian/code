    private void InvokeAsyncImpl(DispatcherOperation operation,
                                 CancellationToken cancellationToken)
    {
        DispatcherHooks hooks = null;
        bool succeeded = false;
 
        // Could be a non-dispatcher thread, lock to read
        lock(_instanceLock)
        {
            if (!cancellationToken.IsCancellationRequested &&
                !_hasShutdownFinished && 
                !Environment.HasShutdownStarted)
            {
                // Add the operation to the work queue
                operation._item = _queue.Enqueue(operation.Priority, operation);
 
                // Make sure we will wake up to process this operation.
                succeeded = RequestProcessing();
 
                if (succeeded)
                {
                    // Grab the hooks to use inside the lock; but we will
                    // call them below, outside of the lock.
                    hooks = _hooks;
                }
                else
                {
                    // Dequeue the item since we failed to request
                    // processing for it.  Note we will mark it aborted
                    // below.
                    _queue.RemoveItem(operation._item);
                }
            } 
        }
        // Rest of method, shortened for brevity.
    }
