    public class Dispatcher : IDisposable
    {
        private readonly ConcurrentQueue<IDomainEvent> queue = new ConcurrentQueue<IDomainEvent>();
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        // Subscribe code...
        public void Publish(IDomainEvent domainEvent)
        {
            queue.Enqueue(domainEvent);
            if (IsPublishing)
            {
                return;
            }
            PublishQueue();
        }
        private void PublishQueue()
        {
            IDomainEvent domainEvent;
            while (queue.TryDequeue(out domainEvent))
            {
                InternalPublish(domainEvent);
            }
        }
        private void InternalPublish(IDomainEvent domainEvent)
        {
            semaphore.Wait();
            try
            {
                // Get event subscriber(s) from concurrent dictionary...
                
                foreach (Action<IDomainEvent> subscriber in eventSubscribers)
                {
                    subscriber(domainEvent);
                }
            }
            finally
            {
                semaphore.Release();
            }
            // Necessary, as calls to Publish during publishing could have queued events and returned.
            PublishQueue();
        }
        private bool IsPublishing
        {
            get { return semaphore.CurrentCount < 1; }
        }
        // Dispose pattern for semaphore...
    }
}
