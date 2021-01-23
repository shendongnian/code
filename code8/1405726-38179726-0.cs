            DateTime now = DateTime.Now;
            DateTime utcTimeNow = TimeZoneInfo.ConvertTimeToUtc(now);
            TimeZoneInfo melbourneTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
            DateTime melbourneTime = TimeZoneInfo.ConvertTimeFromUtc(utcTimeNow, melbourneTimeZone);
            Console.WriteLine("The date and time are {0} {1}.", melbourneTime, melbourneTimeZone.IsDaylightSavingTime(melbourneTime) ? melbourneTimeZone.DaylightName : melbourneTimeZone.StandardName);
            TimeZoneInfo laTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTime laTime = TimeZoneInfo.ConvertTimeFromUtc(utcTimeNow, laTimeZone);
            Console.WriteLine("The date and time are {0} {1}.", laTime, laTimeZone.IsDaylightSavingTime(laTime) ? laTimeZone.DaylightName : laTimeZone.StandardName);
            Console.ReadKey();
