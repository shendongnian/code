    public void ScheduleWorkItem(Func<CancellationToken, Task> workItem) {
        Debug.Assert(workItem != null);
 
        if (_cancellationTokenHelper.IsCancellationRequested) {
            return; // we're not going to run this work item
        }
 
        // Unsafe* since we want to get rid of Principal and other constructs specific to the current ExecutionContext
        ThreadPool.UnsafeQueueUserWorkItem(state => {
            lock (this) {
                if (_cancellationTokenHelper.IsCancellationRequested) {
                    return; // we're not going to run this work item
                }
                else {
                    _numExecutingWorkItems++;
                }
            }
 
            RunWorkItemImpl((Func<CancellationToken, Task>)state);
        }, workItem);
    }
    // we can use 'async void' here since we're guaranteed to be off the AspNetSynchronizationContext
    private async void RunWorkItemImpl(Func<CancellationToken, Task> workItem) {
        Task returnedTask = null;
        try {
            returnedTask = workItem(_cancellationTokenHelper.Token);
            await returnedTask.ConfigureAwait(continueOnCapturedContext: false);
        }
        catch (Exception ex) {
            // ---- exceptions caused by the returned task being canceled
            if (returnedTask != null && returnedTask.IsCanceled) {
                return;
            }
 
            // ---- exceptions caused by CancellationToken.ThrowIfCancellationRequested()
            OperationCanceledException operationCanceledException = ex as OperationCanceledException;
            if (operationCanceledException != null && operationCanceledException.CancellationToken == _cancellationTokenHelper.Token) {
                return;
            }
 
            _logCallback(AppDomain.CurrentDomain, ex); // method shouldn't throw
        }
        finally {
            WorkItemComplete();
        }
    }
