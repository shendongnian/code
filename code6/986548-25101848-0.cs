    public static class Extensions
    {
        public static ThreadPoolTaskAwaiter WithThreadPool(this Task task)
        {
            return new ThreadPoolTaskAwaiter(task);
        }
        public class ThreadPoolTaskAwaiter : INotifyCompletion
        {
            private readonly TaskAwaiter m_awaiter;
            public ThreadPoolTaskAwaiter(Task task)
            {
                if (task == null) throw new ArgumentNullException("task");
                m_awaiter = task.GetAwaiter();
            }
            public ThreadPoolTaskAwaiter GetAwaiter() { return this; }
            public bool IsCompleted { get { return m_awaiter.IsCompleted; } }
            public void OnCompleted(Action continuation)
            {
                if (Thread.CurrentThread.IsThreadPoolThread)
                {
                    continuation();
                }
                else
                {
                    Task.Run(continuation);
                }                
            }
            public void GetResult()
            {
                m_awaiter.GetResult();
            }
        }
    }
