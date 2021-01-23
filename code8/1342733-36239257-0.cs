    public String ElapsedTime
        {
            get
            { 
                TimeSpan ts = sw.Elapsed;
                return String.Format("{0:00}:{1:00}:{2:00}",
            ts.Hours, ts.Minutes, ts.Seconds / 10);
            }
        }
