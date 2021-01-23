    public class MyScheduler : TaskScheduler
    {
        public override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false; // Never allow inlining.
        }
        // TODO: Rest of TaskScheduler implementation goes here...
    }
