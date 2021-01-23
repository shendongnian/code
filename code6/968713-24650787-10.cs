    class DebounceTimer : IDisposable
    {
        private readonly System.Threading.Timer _timer;
        private readonly int _delayInMs;
        private readonly object _lock = new object();
        private DateTime _lastResetTime = DateTime.MinValue;
        
        private Action _lastCallback = () => { };
        
        public DebounceTimer(int delayInMs)
        {
            _delayInMs = delayInMs;
            // the timer is initially stopped
            _timer = new System.Threading.Timer(
                callback: _ => InvokeIfTimeElapsed(),
                state: null,
                dueTime: System.Threading.Timeout.Infinite, 
                period: System.Threading.Timeout.Infinite);
        }
        private void InvokeIfTimeElapsed()
        {
            Action callback;
            lock (_lock)
            {
                // if reset just happened, skip the whole thing
                if ((DateTime.UtcNow - _lastResetTime).TotalMilliseconds < _delayInMs)
                    return;
                else
                    callback = _lastCallback;
            }
            // if we're here, we are sure we've got the right callback - invoke it.
            // (even if reset happens now, we captured the previous callback 
            // inside the lock)
            callback();
        }
        public void Reset(Action callback)
        {
            lock (_lock)
            {
                // reset timer
                _timer.Change(
                    dueTime: _delayInMs,
                    period: System.Threading.Timeout.Infinite);
                
                // save last reset timestamp
                _lastResetTime = DateTime.UtcNow;
                
                // set the new callback
                _lastCallback = callback;
            }
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
