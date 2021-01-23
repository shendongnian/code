    internal class SingleThreadedTaskScheduler : TaskScheduler
    {
        private readonly LinkedList<Task> tasks = new LinkedList<Task>(); // protected by lock(_tasks) 
        public SingleThreadedTaskScheduler()
        {
            RunThread();
        }
        protected sealed override void QueueTask(Task task)
        {
            lock (tasks)
            {
                tasks.AddLast(task);
                Monitor.Pulse(tasks);
            }
        }
        private void RunThread()
        {
            new Thread(_ =>
            {
                while (true)
                {
                    Task item;
                    lock (tasks)
                    {
                        if (tasks.Count == 0)
                        {
                            Monitor.Wait(tasks);
                        }
                        item = tasks.First.Value;
                        tasks.RemoveFirst();
                    }
                    base.TryExecuteTask(item);
                }
            }).Start();
        }
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
        protected sealed override bool TryDequeue(Task task)
        {
            lock (tasks) 
                return tasks.Remove(task);
        }
        public sealed override int MaximumConcurrencyLevel
        {
            get { return 1; }
        }
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(tasks, ref lockTaken);
                if (lockTaken) return tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(tasks);
            }
        }
    }
