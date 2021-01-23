    var dateToCheck = new DateTime(2015, 08, 05);
    var holidays = new HashSet<DateTime> { new DateTime(2015, 08, 04) };
    var firstThreeWorkdays =
        Enumerable.Range(1, DateTime.DaysInMonth(dateToCheck.Year, dateToCheck.Month))
            .Select(o => new DateTime(dateToCheck.Year, dateToCheck.Month, o))
            .Where(o => o.DayOfWeek != DayOfWeek.Saturday && o.DayOfWeek != DayOfWeek.Sunday
                && !holidays.Contains(o))
            .Take(3);
    var isDateInFirstThreeBusinessDays = firstThreeWorkdays.Contains(dateToCheck);
