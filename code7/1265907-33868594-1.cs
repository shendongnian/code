    public static void SetSynchronizationContext(SynchronizationContext syncContext)
        {
            ExecutionContext ec = Thread.CurrentThread.GetMutableExecutionContext();
            ec.SynchronizationContext = syncContext;
            ec.SynchronizationContextNoFlow = syncContext;
        }
