        public static int Interval = 5000;
        public static int IntervalLeft = Interval;
                Timer.Elapsed += _timer_Elapsed;
                Timer.Enabled = true;
                Timer.Interval = Interval;
                CountDownTimer.Elapsed += _CountDowntimer_Elapsed;
                CountDownTimer.Enabled = true;
                CountDownTimer.Interval = 1000;
                CountDownTimer.Start();
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CountDownTimer.Stop();
            Timer.Stop();
             DOES THE JOB HERE
            Timer.Start();
            CountDownTimer.Start();
            IntervalLeft = Interval;
        }
       private static void _CountDowntimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Zipper.ClearCurrentConsoleLine();
            IntervalLeft = (IntervalLeft - 1000);
            Console.Write("Starts in" + IntervalLeft/1000);
        }
