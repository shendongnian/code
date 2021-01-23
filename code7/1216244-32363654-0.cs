    class LastInLocker
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly Object _syncObject = new Object();
        public void Wait()
        {
            Wait(CancellationToken.None);
        }
        public void Wait(CancellationToken earlyCancellationToken)
        {
            var token = ReplaceTokenSource(earlyCancellationToken);
            _semaphore.Wait(token);
        }
        public Task WaitAsync()
        {
            return WaitAsync(CancellationToken.None);
        }
        public async Task WaitAsync(CancellationToken earlyCancellationToken)
        {
            var token = ReplaceTokenSource(earlyCancellationToken);
            
            //I await here because if ReplaceTokenSource thows a exception I want the 
            //observing of that exception to be deferred until the caller awaits my 
            //returned task.
            await _semaphore.WaitAsync(earlyCancellationToken).ConfigureAwait(false);
        }
        public void Release()
        {
            _semaphore.Release();
        }
        private CancellationToken ReplaceTokenSource(CancellationToken earlyCancellationToken)
        {
            CancellationToken token;
            lock (_syncObject)
            {
                _cts.Cancel();
                _cts = CancellationTokenSource.CreateLinkedTokenSource(earlyCancellationToken);
                token = _cts.Token;
            }
            return token;
        }
    }
