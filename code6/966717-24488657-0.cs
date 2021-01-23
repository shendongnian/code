        public static IEnumerable<DateTime> GetThisMonthMondaysTimes()
        {
            int daysToMonday = (int) DateTime.Today.DayOfWeek - 1;
            DateTime nearestMonday = DateTime.Today.AddDays(daysToMonday);
            for (DateTime day = nearestMonday; day.Month == nearestMonday.Month; day = day.AddDays(7))
                yield return day;
        }
