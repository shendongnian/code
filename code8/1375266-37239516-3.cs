    private readonly SQLiteConnection _sharedConnection;
    private readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
    public async Task<TResult> PostAsync<TResult>(Func<SQLiteConnection, TResult> dbFunc, CancellationToken ct)
    {
        TResult result;
        bool needToRelease = false;
        
        try
        {
            await Semaphore.WaitAsync(ct).ConfigureAwait(false);
            // If we got this far, Release *must* be called.
            needToRelease = true;
            ct.ThrowIfCancellationRequested();
            // Push the work off to the thread pool in the event that
            // WaitAsync completed synchronously and we're still on the UI thread.
            result = await Task
                .Run(() => dbFunc(_sharedConnection), ct)
                .ConfigureAwait(false);
        }
        finally
        {
            if (needToRelease) {
                Semaphore.Release();
            }
        }
        return result;
    }
