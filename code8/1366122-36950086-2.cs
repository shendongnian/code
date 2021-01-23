    public static void QueueBackgroundWorkItem(
        Action<CancellationToken> workItem) {
        if (workItem == null) {
            throw new ArgumentNullException("workItem");
        }
 
        QueueBackgroundWorkItem(ct => { workItem(ct); return _completedTask; });
    }
 
    public static void QueueBackgroundWorkItem(
        Func<CancellationToken, Task> workItem) {
        if (workItem == null) {
            throw new ArgumentNullException("workItem");
        }
        if (_theHostingEnvironment == null) {
            throw new InvalidOperationException(); // can only be called within an ASP.NET AppDomain
        }
 
        _theHostingEnvironment.QueueBackgroundWorkItemInternal(workItem);
    }
 
    private void QueueBackgroundWorkItemInternal(
        Func<CancellationToken, Task> workItem) {
        Debug.Assert(workItem != null);
 
        BackgroundWorkScheduler scheduler = Volatile.Read(ref _backgroundWorkScheduler);
 
        // If the scheduler doesn't exist, lazily create it, but only allow one instance to ever be published to the backing field
        if (scheduler == null) {
            BackgroundWorkScheduler newlyCreatedScheduler = new BackgroundWorkScheduler(UnregisterObject, Misc.WriteUnhandledExceptionToEventLog);
            scheduler = Interlocked.CompareExchange(ref _backgroundWorkScheduler, newlyCreatedScheduler, null) ?? newlyCreatedScheduler;
            if (scheduler == newlyCreatedScheduler) {
                RegisterObject(scheduler); // Only call RegisterObject if we just created the "winning" one
            }
        }
 
        scheduler.ScheduleWorkItem(workItem);
    }
