     // Get Tokyo Standard Time zone
          TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
          DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);      
          Console.WriteLine("Time in {0} zone: {1}", tst.IsDaylightSavingTime(tstTime) ?
                            tst.DaylightName : tst.StandardName, tstTime);
          Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));
