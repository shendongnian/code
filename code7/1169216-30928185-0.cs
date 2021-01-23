    public static void DefineYesterday( out LocalDateTime yesterdayStartOfDay , out LocalDateTime yesterdayEndOfDay )
    {
      BclDateTimeZone tz         = NodaTime.TimeZones.BclDateTimeZone.ForSystemDefault() ;
      LocalDateTime   now        = SystemClock.Instance.Now.InZone(tz).LocalDateTime ;
      LocalDateTime   startOfDay = now.PlusTicks( - now.TickOfDay ) ;
      
      yesterdayStartOfDay = startOfDay.PlusDays(  -1 ) ;
      yesterdayEndOfDay   = startOfDay.PlusTicks( -1 ) ;
      
      return;
    }
