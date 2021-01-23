    public class PerformanceWatcher : IDisposable
    {
        private System.Diagnostics.Stopwatch _sw;
        private Timer _timer;
        private int _maxSeconds;
        
        public bool TimeLimitExceeded { get; private set; }
        public PerformanceWatcher(int maxSeconds)
        {
            _maxSeconds = maxSeconds;
            // start the StopWatch
            _sw = System.Diagnostics.Stopwatch.StartNew();
            // check every second
            _timer = new Timer(1000);
            _timer.AutoReset = true;
            // set event-handler
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Enabled = true;
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // check if time limit was reached
            if (this._sw.Elapsed.TotalSeconds > _maxSeconds)
            {
                this.TimeLimitExceeded = true;
            }
        }
        
        public void Dispose()
        {
            this._timer.Dispose();
        }
    }
