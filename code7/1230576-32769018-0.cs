    class TimeInterval
    {
      private DateTime start;
      private DateTime end;
      public TimeInterval(DateTime start, DateTime end)
      {
        this.start = start;
        this.end = end;
      }
      public bool Contains(DateTime moment)
      {
        return moment >= this.start && moment <= this.end;
      }
    }
