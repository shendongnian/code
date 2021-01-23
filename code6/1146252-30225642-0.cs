    public class PeriodicTimerTask : IDisposable
    {
        private readonly System.Timers.Timer _timer;
        private CancellationTokenSource _tokenSource;
        private readonly ManualResetEventSlim _callbackComplete;
        private readonly Action<CancellationToken> _userTask;
        public PeriodicTimerTask(TimeSpan interval, Action<CancellationToken> userTask)
        {
            _tokenSource = new CancellationTokenSource();
            _userTask = userTask;
            _callbackComplete = new ManualResetEventSlim(true);
            _timer = new System.Timers.Timer(interval.TotalMilliseconds);
        }
        public void Start()
        {
            if (_tokenSource != null)
            {
                _timer.Elapsed += (sender, e) => Tick();
                _timer.AutoReset = true;
                _timer.Start();
            }
        }
        public void Stop()
        {
            var tokenSource = Interlocked.Exchange(ref _tokenSource, null);
            if (tokenSource != null)
            {
                _timer.Stop();
                tokenSource.Cancel();
                _callbackComplete.Wait();
                _timer.Dispose();
                _callbackComplete.Dispose();
                tokenSource.Dispose();
            }
        }
        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }
        private void Tick()
        {
            if (!_tokenSource.IsCancellationRequested)
            {
                _callbackComplete.Wait(_tokenSource.Token); // prevent multiple ticks.
                _callbackComplete.Reset();
                try
                {
                    _userTask(_tokenSource.Token);
                }
                catch (OperationCanceledException) { }
                finally
                {
                    _callbackComplete.Set();
                }
            }
        }
    }
