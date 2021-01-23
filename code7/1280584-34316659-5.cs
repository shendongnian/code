    private class TaskDelaySource
    {
        private readonly int maxTasks;
        private readonly TimeSpan inInterval;
        private readonly Queue<long> ticks = new Queue<long>();
    
        public TaskDelaySource(int maxTasks, TimeSpan inInterval)
        {
            this.maxTasks = maxTasks;
            this.inInterval = inInterval;
        }
    
        public async Task Delay()
        {
            // We will measure time of last maxTasks tasks.
            while (ticks.Count > maxTasks)
                ticks.Dequeue();
    
            if (ticks.Any())
            {
                var now = DateTime.UtcNow.Ticks;
                var lastTick = ticks.First();
                // Calculate interval between last maxTasks task and current time
                var intervalSinceLastTask = TimeSpan.FromTicks(now - lastTick);
    
                if (intervalSinceLastTask < inInterval)
                    await Task.Delay((int)(inInterval - intervalSinceLastTask).TotalMilliseconds);
            }
    
            ticks.Enqueue(DateTime.UtcNow.Ticks);
        }
    }
