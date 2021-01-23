    class DebounceTimer : IDisposable
    {
        private readonly System.Threading.Timer _timer;
        private readonly int _delayInMs;
        private Action _lastCallback = () => { };
        
        public DebounceTimer(int delayInMs)
        {
            _delayInMs = delayInMs;
            // the timer is initially stopped
            _timer = new System.Threading.Timer(
                callback: _ => _lastCallback(),
                state: null,
                dueTime: System.Threading.Timeout.Infinite, 
                period: System.Threading.Timeout.Infinite);
        }
        public void Reset(Action callback)
        {
            _timer.Change(dueTime: _delayInMs, period: System.Threading.Timeout.Infinite);
            // note: no thread synchronization is taken into account here,
            // a race condition might occur where the same callback would
            // be executed twice
            _lastCallback = callback;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
