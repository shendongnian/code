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
