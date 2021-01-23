    public void ListDSTAdjustmentRules()
        {
            var tz = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timeZoneInfo in tz)
            {
                var adjustments = timeZoneInfo.GetAdjustmentRules();
                foreach (var adjustmentRule in adjustments)
                {
                    Console.WriteLine(
                        "TimeZone: {0} SupportsDST: {1} DateStart: {2} DateEnd: {3} Delta: {4}",
                        timeZoneInfo.DisplayName, timeZoneInfo.SupportsDaylightSavingTime, adjustmentRule.DateStart,
                        adjustmentRule.DateEnd, adjustmentRule.DaylightDelta);
                }
                
            }
        }
