    public class TimeGatedSemaphore
    {
        private readonly SemaphoreSlim semaphore;
        public TimeGatedSemaphore(int maxRequest, TimeSpan minimumHoldTime)
        {
            semaphore = new SemaphoreSlim(maxRequest);
            MinimumHoldTime = minimumHoldTime;
        }
        public TimeSpan MinimumHoldTime { get; }
        public async Task<IDisposable> WaitAsync()
        {
            await semaphore.WaitAsync();
            return new InternalReleaser(semaphore, Task.Delay(MinimumHoldTime));
        }
        private class InternalReleaser : IDisposable
        {
            private readonly SemaphoreSlim semaphoreToRelease;
            private readonly Task notBeforeTask;
            public InternalReleaser(SemaphoreSlim semaphoreSlim, Task dependantTask)
            {
                semaphoreToRelease = semaphoreSlim;
                notBeforeTask = dependantTask;
            }
            public void Dispose()
            {
                notBeforeTask.ContinueWith(_ => semaphoreToRelease.Release());
            }
        }
    }
