        public static Dictionary<int, string> MonthsBetween(
            DateTime startDate,
            DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;
            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }
            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            var result = new Dictionary<int, string>();
            while (iterator <= limit)
            {
                if (!result.Keys.Contains(iterator.Month))
                    result.Add(iterator.Month, dateTimeFormat.GetMonthName(iterator.Month));
                iterator = iterator.AddMonths(1);
            }
            return result;
        }
