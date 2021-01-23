    using System;
    using System.Timers;
    public static class TheStaticObject
    {
        private static Timer _timer;
        public static void InitializeTheObject()
        {
            _timer = new Timer
            {
                AutoReset = true,
                Interval = TimeSpan.FromMinutes(10).TotalMilliseconds
            };
            _timer.Elapsed += RunEvery10Minutes;
            _timer.Start();
        }
        public static void RunEvery10Minutes(object sender, ElapsedEventArgs e)
        {
            // do something
        }
    }
