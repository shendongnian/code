        static IEnumerable<DateTime> GetSaturdaysInMonth(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Select(day => new DateTime(year, month, day))
                .Where(dt => dt.DayOfWeek == DayOfWeek.Saturday);
        }
