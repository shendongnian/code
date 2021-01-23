    private readonly Object syncLock = new Object();
    private readonly TimeSpan minTimeout = TimeSpan.FromSeconds(5);
    private volatile DateTime nextCallDate = DateTime.MinValue;
    public async Task<Result> RequestData(...) {
        DateTime possibleCallDate = DateTime.Now;
        lock(syncLock) {
            // When is it possible to make the next call?
            if (nextCallDate > possibleCallDate) {
                possibleCallDate = nextCallDate;
            }
            nextCallDate = possibleCallDate + minTimeout;
        }
        TimeSpan waitingTime = possibleCallDate - DateTime.Now;
        if (waitingTime > TimeSpan.Zero) {
            await Task.Delay(waitingTime);
        }
        return await ... /* the actual call to API */ ...;
    }
