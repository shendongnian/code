        public void StartTimer(DateTime time)
        {
            const int fourHoursInMilliseconds = 4 * 3600 * 1000;
            var fourHourTimer = new Timer() {Interval = fourHoursInMilliseconds};
            fourHourTimer.Elapsed += (sender, args) =>
            {
                Console.WriteLine("FourHours");
            };
            var span = time - DateTime.Now;
            var timer = new Timer {Interval = span.TotalMilliseconds, AutoReset = false};
            timer.Elapsed += (sender, args) => { fourHourTimer.Start(); Console.WriteLine("First"); };
            timer.Start();
        }
