    public String ElapsedTime
    {
        get
        {
            return string.Format("{0:00}:{1:00}:{2:00}", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds / 10);
        }
    }
