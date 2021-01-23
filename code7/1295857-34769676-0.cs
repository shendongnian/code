    DateTimeOffset example = new DateTimeOffset(2015, 10, 25, 2, 30, 0, 
      new TimeSpan(0, 2, 0, 0));
    
    TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
    if (tst.IsAmbiguousTime(example))
      Console.Write("Ambiguous time");
