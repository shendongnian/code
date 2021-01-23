    public static Task Run(Action action)
    {
        return Task.InternalStartNew(null, action, null, default(CancellationToken), TaskScheduler.Default,
            TaskCreationOptions.DenyChildAttach, InternalTaskOptions.None, ref stackMark);
    }
