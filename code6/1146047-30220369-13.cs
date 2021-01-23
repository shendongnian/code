    Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
    DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;
    var combinedTrends = from daily in _dailyDict
                            join weeklySub in _weeklyDict on GetWeekOfYear(cal.GetWeekOfYear(DateTime.Parse(daily.Key), CalendarWeekRule.FirstDay, firstDayOfWeek)) equals GetWeekOfYear(cal.GetWeekOfYear(DateTime.Parse(weeklySub.Key.Substring(0, 10)), CalendarWeekRule.FirstDay, firstDayOfWeek)) into weeklyGroup
                            from weekly in weeklyGroup.DefaultIfEmpty(new KeyValuePair<string, int>(GetWeekRange(DateTime.Parse(daily.Key), firstDayOfWeek), 0))
                            select new GoogleTrends
                            {
                                Date = DateTime.Parse(daily.Key),
                                WeekStart = DateTime.Parse(weekly.Key.Substring(0, 10)),
                                WeekEnd = DateTime.Parse(weekly.Key.Substring(13, 10)),
                                DailyIndex = daily.Value,
                                WeeklyIndex = weekly.Value
                            };
