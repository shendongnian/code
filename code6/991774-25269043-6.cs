    public class PeriodicalNotifier : IDisposable
    {
        private readonly Timer _timer;
        private readonly AsyncManualResetEvent _asyncManualResetEvent;
        public PeriodicalNotifier(TimeSpan autoNotifyInterval)
        {
            _asyncManualResetEvent = new AsyncManualResetEvent();
            _timer = new Timer(_ => Notify(), null, TimeSpan.Zero, autoNotifyInterval);
        }
        public async Task WaitForNotifictionAsync(CancellationToken cancellationToken)
        {
            await _asyncManualResetEvent.WaitAsync().WithCancellation(cancellationToken);
            _asyncManualResetEvent.Reset();
        }
        public void Notify()
        {
            _asyncManualResetEvent.Set();
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
