    public class TestTaskScheduler : TaskScheduler
    {
        private static readonly MethodInfo queueTask = GetProtectedMethodInfo("QueueTask");
        private static readonly MethodInfo tryExecuteTaskInline = GetProtectedMethodInfo("TryExecuteTaskInline");
        private static readonly MethodInfo getScheduledTasks = GetProtectedMethodInfo("GetScheduledTasks");
        private readonly TaskScheduler taskScheduler;
        public TestTaskScheduler(TaskScheduler taskScheduler)
        {
            this.taskScheduler = taskScheduler;
        }
        public int TaskCount { get; private set; }
        protected override void QueueTask(Task task)
        {
            TaskCount++;
            CallProtectedMethod(queueTask, task);
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return (bool)CallProtectedMethod(tryExecuteTaskInline, task, taskWasPreviouslyQueued);
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return (IEnumerable<Task>)CallProtectedMethod(getScheduledTasks);
        }
        private object CallProtectedMethod(MethodInfo methodInfo, params object[] args)
        {
            return methodInfo.Invoke(taskScheduler, args);
        }
        private static MethodInfo GetProtectedMethodInfo(string methodName)
        {
            return typeof(TaskScheduler).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
