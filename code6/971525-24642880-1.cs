    public string SqlDate
    {
      get { return DaysSince1900( DateTime.Now ).ToString() ; }
    }
    private int DaysSince1900( DateTime now )
    {
      TimeSpan period = now.Date - SqlServerEpoch ;
      return period.Days ;
    }
    static readonly DateTime SqlServerEpoch = new DateTime( 1900 , 1 , 1 ) ;
