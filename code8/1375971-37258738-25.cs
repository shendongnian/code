    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ReflectionMagic;
    public class TestTaskScheduler : TaskScheduler
    {
        private readonly dynamic taskScheduler;
        public TestTaskScheduler(TaskScheduler taskScheduler)
        {
            this.taskScheduler = taskScheduler.AsDynamic();
        }
        public int TaskCount { get; private set; }
        protected override void QueueTask(Task task)
        {
            TaskCount++;
            taskScheduler.QueueTask(task);
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return taskScheduler.TryExecuteTaskInline(task, taskWasPreviouslyQueued);
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return taskScheduler.GetScheduledTasks();
        }
    }
