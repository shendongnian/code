    // ----------------------------------------------------------------------
    public void ExtractSubPeriods()
    {
      foreach ( ITimePeriod subPeriod in GetSubPeriods(
        new TimeRange( new DateTime( 2014, 4, 1 ), new DateTime( 2015, 2, 28 ) ) ) )
      {
        Console.WriteLine( "SubPeriods 1: {0}", subPeriod );
    
      foreach ( ITimePeriod subPeriod in GetSubPeriods(
        new TimeRange( new DateTime( 2014, 7, 1 ), new DateTime( 2015, 6, 30 ) ) ) )
      {
        Console.WriteLine( "SubPeriods 2: {0}", subPeriod );
      }
    
      foreach ( ITimePeriod subPeriod in GetSubPeriods(
        new TimeRange( new DateTime( 2014, 4, 1 ), new DateTime( 2015, 12, 31 ) ) ) )
      {
        Console.WriteLine( "SubPeriods 3: {0}", subPeriod );
      }
    } // ExtractSubPeriods
    
    // ----------------------------------------------------------------------
    public ITimePeriodCollection GetSubPeriods( ITimeRange timeRange )
    {
      ITimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( timeRange );
    
      int startYear = periods.Start.Year;
      int endYear = periods.End.Year + 1;
      for ( int year = startYear; year <= endYear; year++ )
      {
        periods.Add( new TimeRange( new DateTime( year, 4, 1 ), new DateTime( year, 12, 1 ) ) );
      }
    
      TimePeriodIntersector<TimeRange> intersector = new TimePeriodIntersector<TimeRange>();
      return intersector.IntersectPeriods( periods );
    } // GetSubPeriods
