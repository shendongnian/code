        public void startTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(ExecuteTimerJob);
            timer.Interval = 10000; // 10 sec
            timer.Start();
        }
        public static void ExecuteTimerJob(object source, System.Timers.ElapsedEventArgs e)
        {
            // this is the call from C#
            PlanHub.Static_UpdateStatus(123, "some message");
        }
