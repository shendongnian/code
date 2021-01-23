    private readonly Object syncLock = new Object();
    private readonly TimeSpan minTimeout = TimeSpan.FromSeconds(5);
    private DateTime lastCall = DateTime.MinValue;
    public async Task<Result> RequestData(...) {
        lock(syncLock) {
            DateTime now = DateTime.Now;
            TimeSpan passedSinceLastCall = now - lastCall;
            if (passedSinceLastCall < minTimeout) {
                // Waiting the difference between passed time and 5 seconds,
                // e.g. if last call was 2 seconds ago then wait 3 seconds.
                await Task.Delay(minTimeout - passedSinceLastCall);
            }
            lastCall = DateTime.now;
        }
        return await ... /* the actual call to API */ ...;
    }
