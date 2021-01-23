        class Countdown
    {
        private DateTime _startTime;
        private Timer _timer;
        private TimeSpan _countdownTime;
        public string RemainingTime { get; private set; }
        public Countdown(TimeSpan countdownTime)
        {
            this._countdownTime = countdownTime;
            _timer = new Timer(50);
        }
        public void Start()
        {
            _startTime = DateTime.Now;
            _timer.Start();
        }
        private void Timer_Tick(object state)
        {
            DateTime now = DateTime.Now;
            TimeSpan difference = now - _startTime;
            TimeSpan remaining = _countdownTime - difference;
            if (remaining < TimeSpan.Zero)
            {
                _timer.Stop();
                // Raise Event or something
            }
            RemainingTime = remaining.ToString("mm:ss:ff");
        }
    }
