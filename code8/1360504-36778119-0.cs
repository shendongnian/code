    static class TasksExtensions
    {
        public static Task<Task<T>> WhenAny<T>(this IList<Task<T>> tasks, Func<T, bool> filter)
        {
            CompleteOnInvokePromiseFilter<T> action = new CompleteOnInvokePromiseFilter<T>(filter);
            bool flag = false;
            for (int i = 0; i < tasks.Count; i++)
            {
                Task<T> completingTask = tasks[i];
                if (!flag)
                {
                    if (action.IsCompleted) flag = true;
                    else if (completingTask.IsCompleted)
                    {
                        action.Invoke(completingTask);
                        flag = true;
                    }
                    else completingTask.ContinueWith(t =>
                    {
                        action.Invoke(t);
                    });
                }
            }
            
            return action.Task;
        }
    }
    class CompleteOnInvokePromiseFilter<T>
    {
        private int firstTaskAlreadyCompleted;
        private TaskCompletionSource<Task<T>> source;
        private Func<T, bool> filter;
        public CompleteOnInvokePromiseFilter(Func<T, bool> filter)
        {
            this.filter = filter;
            source = new TaskCompletionSource<Task<T>>();
        }
        public void Invoke(Task<T> completingTask)
        {
            if (completingTask.Status == TaskStatus.RanToCompletion && 
                filter(completingTask.Result) && 
                Interlocked.CompareExchange(ref firstTaskAlreadyCompleted, 1, 0) == 0)
            {
                source.TrySetResult(completingTask);
            }
        }
        public Task<Task<T>> Task { get { return source.Task; } }
        public bool IsCompleted { get { return source.Task.IsCompleted; } }
    }
