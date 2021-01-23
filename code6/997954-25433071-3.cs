    public class FixedDegreeSynchronizationContext : SynchronizationContext
    {
        private SemaphoreSlim semaphore;
        public FixedDegreeSynchronizationContext(int maxDegreeOfParallelism)
        {
            semaphore = new SemaphoreSlim(maxDegreeOfParallelism,
                maxDegreeOfParallelism);
        }
        public override async void Post(SendOrPostCallback d, object state)
        {
            await semaphore.WaitAsync().ConfigureAwait(false);
            base.Send(d, state);
            semaphore.Release();
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            semaphore.Wait();
            base.Send(d, state);
            semaphore.Release();
        }
    }
