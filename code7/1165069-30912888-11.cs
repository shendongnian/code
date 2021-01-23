    public override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
    {
        // Allow inlining on our own threads.
        return __attachedScheduler.Value == this && this.TryExecuteTask(task);
    }
