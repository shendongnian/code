    private System.Timers.Timer my_timer(System.Timers.Timer tim, System.Timers.ElapsedEventHandler Tick)
        {
            tim.Interval = 1000;
            tim.Elapsed += new System.Timers.ElapsedEventHandler(Tick);
            tim.Enabled = true;
            return tim;
        }
