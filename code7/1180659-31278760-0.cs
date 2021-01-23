    System.Timers.Timer t = new System.Timers.Timer();
        public void TimerSetup()
        {
            t.Interval = 1000;
            t.Elapsed += ElapsedMethod;
            t.Start();
        }
        public void ElapsedMethod(object sender, System.Timers.ElapsedEventArgs e)
        {
            //do stuff
            t.Interval = t.Interval - 5; //however much you want it to reduce.
        }
