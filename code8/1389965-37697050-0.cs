    internal static bool IsValidLocationForInlining
    {
        get
        {
            // If there's a SynchronizationContext, we'll be conservative and say 
            // this is a bad location to inline.
            var ctx = SynchronizationContext.CurrentNoFlow;
            if (ctx != null && ctx.GetType() != typeof(SynchronizationContext)) return false;
            // Similarly, if there's a non-default TaskScheduler, we'll be conservative
            // and say this is a bad location to inline.
            var sched = TaskScheduler.InternalCurrent;
            return sched == null || sched == TaskScheduler.Default;
        }
    }
