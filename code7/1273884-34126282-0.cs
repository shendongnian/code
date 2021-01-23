    class Worker
    {
        private static readonly TimeSpan _ktotalDuration = TimeSpan.FromSeconds(5);
        private const int _kintervalCount = 20;
        public bool IsPaused { get { return _pauseCompletionSource != null; } }
        public event EventHandler IsPausedChanged;
        private readonly object _lock = new object();
        private CancellationTokenSource _cancelSource;
        private volatile TaskCompletionSource<object> _pauseCompletionSource;
        public async Task Run(IProgress<int> progress)
        {
            _cancelSource = new CancellationTokenSource();
            TimeSpan sleepDuration = TimeSpan.FromTicks(_ktotalDuration.Ticks / _kintervalCount);
            for (int i = 0; i < 100; i += (100 / _kintervalCount))
            {
                progress.Report(i);
                Thread.Sleep(sleepDuration);
                _cancelSource.Token.ThrowIfCancellationRequested();
                TaskCompletionSource<object> pauseCompletionSource;
                
                lock (_lock)
                {
                    pauseCompletionSource = _pauseCompletionSource;
                }
                if (pauseCompletionSource != null)
                {
                    RaiseEvent(IsPausedChanged);
                    try
                    {
                        await pauseCompletionSource.Task;
                    }
                    finally
                    {
                        lock (_lock)
                        {
                            _pauseCompletionSource = null;
                        }
                        RaiseEvent(IsPausedChanged);
                    }
                }
            }
            progress.Report(100);
            lock (_lock)
            {
                _cancelSource.Dispose();
                _cancelSource = null;
                // Just in case pausing lost the race with cancelling or finishing
                _pauseCompletionSource = null;
            }
        }
        public void Cancel()
        {
            lock (_lock)
            {
                if (_cancelSource != null)
                {
                    if (_pauseCompletionSource == null)
                    {
                        _cancelSource.Cancel();
                    }
                    else
                    {
                        _pauseCompletionSource.SetCanceled();
                    }
                }
            }
        }
        public void Pause()
        {
            lock (_lock)
            {
                if (_pauseCompletionSource == null)
                {
                    _pauseCompletionSource = new TaskCompletionSource<object>();
                }
            }
        }
        public void Resume()
        {
            lock (_lock)
            {
                if (_pauseCompletionSource != null)
                {
                    _pauseCompletionSource.SetResult(null);
                }
            }
        }
        private void RaiseEvent(EventHandler handler)
        {
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
