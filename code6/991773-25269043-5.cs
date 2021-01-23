    public class PeriodicalNotifier : IDisposable
    {
        private readonly Timer _timer;
        private readonly AsyncAutoResetEvent _asyncAutoResetEvent;
        public PeriodicalNotifier(TimeSpan autoNotifyInterval)
        {
            _asyncAutoResetEvent = new AsyncAutoResetEvent();
            _timer = new Timer(_ => Notify(), null, TimeSpan.Zero, autoNotifyInterval);
        }
        public Task WaitForNotifictionAsync(CancellationToken cancellationToken)
        {
            return _asyncAutoResetEvent.WaitAsync().WithCancellation(cancellationToken);
        }
        public void Notify()
        {
            _asyncAutoResetEvent.Set();
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
