    using System;
    using System.Timers;
    public class Countdown
    {
        private readonly TimeSpan countdownTime;
        private readonly Timer timer;
        private DateTime startTime;
        public Countdown(TimeSpan countdownTime)
        {
            this.countdownTime = countdownTime;
            this.timer = new Timer(10);
        }
        public string RemainingTime { get; private set; }
        public void Start()
        {
            this.startTime = DateTime.Now;
            this.timer.Start();
        }
        private void Timer_Tick(object state)
        {
            var now = DateTime.Now;
            var difference = now - this.startTime;
            var remaining = this.countdownTime - difference;
            if (remaining < TimeSpan.Zero)
            {
                this.timer.Stop();
                // Raise Event or something
            }
            this.RemainingTime = remaining.ToString("mm:ss:fff");
        }
    }
