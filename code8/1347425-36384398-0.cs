            try
            {
                //cause error !!!!
                DateTime databaseUtcTime = DateTime.Parse("4/2/2016 6:25:20 PM");
                var localTimeTemp = databaseUtcTime.ToLocalTime();
                DateTime origDateTimeUnspecifiedKind = localTimeTemp.ToUniversalTime();
                // FIX: specify the kind
                DateTime origDateTime = new DateTime(origDateTimeUnspecifiedKind.Ticks, DateTimeKind.Unspecified);
                //this is working
                //DateTime origDateTime = DateTime.Parse("4/2/2016 6:25:20 PM");
                string timeZoneName = "Pacific Standard Time";
                TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
                DateTimeOffset localTime = new DateTimeOffset(origDateTime, localTimeZone.GetUtcOffset(origDateTime));
                return localTime;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
