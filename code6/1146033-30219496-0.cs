    var combinedTrends = from daily in _dailyDict
                                     join weekly in _weeklyDict
                                     on DateTime.Parse(daily.Key) equals DateTime.Parse(weekly.Key.Substring(0, 10))
                                     select new GoogleTrends
                                     {
                                         Date = DateTime.Parse(daily.Key),
                                         WeekStart = DateTime.Parse(weekly.Key.Substring(0, 10)),
                                         WeekEnd = DateTime.Parse(weekly.Key.Substring(13, 10)),
                                         DailyIndex = daily.Value,
                                         WeeklyIndex = weekly.Value
                                     };
