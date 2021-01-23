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
            try
            {
                base.Send(d, state);
            }
            finally
            {
                semaphore.Release();
            }
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            semaphore.Wait();
            try
            {
                base.Send(d, state);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
