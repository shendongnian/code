    public sealed class LastInLocker : IDisposable
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _disposed = false;
        public void Wait()
        {
            Wait(CancellationToken.None);
        }
        public void Wait(CancellationToken earlyCancellationToken)
        {
            if(_disposed)
                throw new ObjectDisposedException("LastInLocker");
            var token = ReplaceTokenSource(earlyCancellationToken);
            _semaphore.Wait(token);
        }
        public Task WaitAsync()
        {
            return WaitAsync(CancellationToken.None);
        }
        public async Task WaitAsync(CancellationToken earlyCancellationToken)
        {
            if (_disposed)
                throw new ObjectDisposedException("LastInLocker");
            var token = ReplaceTokenSource(earlyCancellationToken);
            //I await here because if ReplaceTokenSource thows a exception I want the 
            //observing of that exception to be deferred until the caller awaits my 
            //returned task.
            await _semaphore.WaitAsync(earlyCancellationToken).ConfigureAwait(false);
        }
        public void Release()
        {
            if (_disposed)
                throw new ObjectDisposedException("LastInLocker");
            _semaphore.Release();
        }
        private CancellationToken ReplaceTokenSource(CancellationToken earlyCancellationToken)
        {
            var newSource = CancellationTokenSource.CreateLinkedTokenSource(earlyCancellationToken);
            var oldSource = Interlocked.Exchange(ref _cts, newSource);
            oldSource.Cancel();
            return newSource.Token;
        }
        public void Dispose()
        {
            _disposed = true;
            _semaphore.Dispose();
            _cts.Dispose();
        }
    }
