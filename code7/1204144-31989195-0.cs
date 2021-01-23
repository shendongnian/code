    internal abstract class TaskBase
    {
        /// <summary>
        /// Task timer
        /// </summary>
        private readonly Timer _timer;
        /// <summary>
        /// Set refresh time
        /// </summary>
        protected int TimeRefreshSec { get; private set; }
        /// <summary>
        /// Loop of timePassed
        /// </summary>
        protected int TimePassed { get; private set; }
        protected TaskBase(double refreshInterval)
        {
            TimeRefreshSec = (int) refreshInterval / 1000;
            TimePassed = 0;
            _timer = new Timer(refreshInterval) { AutoReset = true };
            _timer.Elapsed += Tick;
        }
        private void Tick(object sender, ElapsedEventArgs e)
        {
            TimePassed += TimeRefreshSec;
            Tick();
        }
        public void Start()
        {
            ResetTimer();
            // Run the task once when starting instead of waiting for a full interval.
            Tick();
            OnStart();
        }
        public void Stop()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
                OnStop();
            }
        }
        protected virtual void ResetTimer()
        {
            TimePassed = 0;
            if (_timer.Enabled) _timer.Stop();
            _timer.Start();
        }
        /// <summary>
        /// Implement here a specific behavior when task is stopped.
        /// </summary>
        protected abstract void OnStop();
        /// <summary>
        /// Implement here a specific behavior when task is started.
        /// </summary>
        protected abstract void OnStart();
        /// <summary>
        /// This method is executed each time the task's timer has reached the interval specified in the constructor.
        /// Time counters are automatically updated.
        /// </summary>
        protected abstract void Tick();
    }
