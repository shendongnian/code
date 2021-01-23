    public class DebounceTimer : IDisposable
    {
        private readonly System.Threading.Timer _timer;
        private readonly int _delayInMs;
        
        public DebounceTimer(Action callback, int delayInMs)
        {
            _delayInMs = delayInMs;
            // the timer is initially stopped
            _timer = new System.Threading.Timer(
                callback: _ => callback(),
                state: null,
                dueTime: System.Threading.Timeout.Infinite, 
                period: System.Threading.Timeout.Infinite);
        }
        public void Reset()
        {
            // each call to Reset() resets the timer
            _timer.Change(
                dueTime: _delayInMs,
                period: System.Threading.Timeout.Infinite);
        }
        public void Dispose()
        {
            // timers should be disposed when you're done using them
            _timer.Dispose();
        }
    }
