    public class YieldTask : Task
    {
        public YieldTask() : base(() => {})
        {
            Start(TaskScheduler.Default);
        }
        public new TaskAwaiterWrapper GetAwaiter() => new TaskAwaiterWrapper(base.GetAwaiter());
    }
    public struct TaskAwaiterWrapper : INotifyCompletion
    {
        private TaskAwaiter _taskAwaiter;
        public TaskAwaiterWrapper(TaskAwaiter taskAwaiter)
        {
            _taskAwaiter = taskAwaiter;
        }
        public bool IsCompleted => false;
        public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(continuation);
        public void GetResult() => _taskAwaiter.GetResult();
    }
