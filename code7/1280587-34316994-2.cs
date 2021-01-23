    public class Throttler
    {
        private TaskQueue queue;
        public Throttler(int requestsPerSecond)
        {
            queue = new TaskQueue(requestsPerSecond);
        }
        public Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            var unused = queue.Enqueue(() =>
            {
                tcs.Match(taskGenerator());
                return Task.Delay(TimeSpan.FromSeconds(1));
            });
            return tcs.Task;
        }
        public Task Enqueue<T>(Func<Task> taskGenerator)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            var unused = queue.Enqueue(() =>
            {
                tcs.Match(taskGenerator());
                return Task.Delay(TimeSpan.FromSeconds(1));
            });
            return tcs.Task;
        }
    }
