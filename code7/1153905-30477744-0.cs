      //Setup a time range
    TimeRange timeRange1 = new TimeRange(
            new DateTime( 2011, 2, 22, 14, 0, 0 ),
            new DateTime( 2011, 2, 22, 18, 0, 0 ) );
          Console.WriteLine( "TimeRange1: " + timeRange1 );
          // > TimeRange1: 22.02.2011 14:00:00 - 18:00:00 | 04:00:00
        
      // --- Setu uptime range 2 ---
      TimeRange timeRange2 = new TimeRange(
        new DateTime( 2011, 2, 22, 15, 0, 0 ),
        new TimeSpan( 2, 0, 0 ) );
      Console.WriteLine( "TimeRange2: " + timeRange2 );
      // > TimeRange2: 22.02.2011 15:00:00 - 17:00:00 | 02:00:00
    
    
      // --- relation ---
      Console.WriteLine( "TimeRange1.GetRelation( TimeRange2 ): " +
                         timeRange1.GetRelation( timeRange2 ) );
    
      // --- intersection ---
      Console.WriteLine( "TimeRange1.GetIntersection( TimeRange2 ): " +
                         timeRange1.GetIntersection( timeRange2 ) );
      // > TimeRange1.GetIntersection( TimeRange2 ):
      //             22.02.2011 15:00:00 - 17:00:00 | 02:00:00
