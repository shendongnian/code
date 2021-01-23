    public static Task<T> ContinueWithUsingSyncContextWorkaround<T>(this Task<T> task,
                                                   Action<Task<T>> continuationAction, 
                                                   CancellationToken cancellationToken,
                                                   TaskContinuationOptions continuationOptions,
                                                   TaskScheduler scheduler,
                                                   SynchronizationContext sc)
