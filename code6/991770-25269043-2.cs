    public class PeriodicalNotifier : IDisposable
    {
        private readonly Timer _timer;
        private readonly BufferBlock<object> _buffer; 
        public PeriodicalNotifier(TimeSpan autoNotifyInterval)
        {
            _buffer = new BufferBlock<object>();
            _timer = new Timer(_ => Notify(), null, TimeSpan.Zero, autoNotifyInterval);
        }
        public async Task WaitForNotifictionAsync(CancellationToken cancellationToken)
        {
            if (await _buffer.OutputAvailableAsync(cancellationToken))
            {
                IList<object> items;
                _buffer.TryReceiveAll(out items);
            }
        }
        public void Notify()
        {
            _buffer.Post(null);
        }
        public void Dispose()
        {
            _buffer.Complete();
            _timer.Dispose();
        }
    }
