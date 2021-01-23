    public String ElapsedTime
    {
        get
        { 
          return String.Format("{0:00}:{1:00}:{2:00}", sw.Elapsed);
        }
    }
