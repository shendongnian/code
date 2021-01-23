    public override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
    {
        // Don't allow inlining on a thread pool thread.
        return !Thread.CurrentThread.IsThreadPoolThread && this.TryExecuteTask(task);
    }
