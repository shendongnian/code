    class Scheduler
    {
        private static readonly Priority[] Priorities =
            (Priority[])Enum.GetValues(typeof(Priority));
        private readonly IReadOnlyDictionary<Priority, ConcurrentQueue<Func<Task>>> queues;
        private readonly ActionBlock<Func<Task>> executor;
        private readonly SemaphoreSlim semaphore;
        public Scheduler(int degreeOfParallelism)
        {
            queues = Priorities.ToDictionary(
                priority => priority, _ => new ConcurrentQueue<Func<Task>>());
            executor = new ActionBlock<Func<Task>>(
                invocation => invocation(),
                new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = degreeOfParallelism,
                    BoundedCapacity = degreeOfParallelism
                });
            semaphore = new SemaphoreSlim(0);
            Task.Run(Watch);
        }
        private async Task Watch()
        {
            while (true)
            {
                await semaphore.WaitAsync();
                // find item with highest priority and send it for execution
                foreach (var priority in Priorities.Reverse())
                {
                    Func<Task> invocation;
                    if (queues[priority].TryDequeue(out invocation))
                    {
                        await executor.SendAsync(invocation);
                    }
                }
            }
        }
        public void Invoke(Func<Task> invocation, Priority priority)
        {
            queues[priority].Enqueue(invocation);
            semaphore.Release(1);
        }
    }
