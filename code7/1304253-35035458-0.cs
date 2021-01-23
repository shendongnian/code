    public static IEnumerable<DateTime> GetLastWeekDatesOfMonth(int year, int month, DayOfWeek firstDayOfWeek = DayOfWeek.Monday, bool includeLaterMonths = false)
    { 
        DateTime first = new DateTime(year, month, 1);
        int daysOffset = (int)firstDayOfWeek - (int)first.DayOfWeek;
        if (daysOffset < 0)
            daysOffset = 7 - Math.Abs(daysOffset);
        DateTime firstWeekDay = first.AddDays(daysOffset);
        DateTime current = firstWeekDay.AddDays(-1); // last before week start
        if (current.Month != month)
            current = current.AddDays(7);
        yield return current;
        if (includeLaterMonths)
        {
            while (true)
            {
                current = current.AddDays(7);
                yield return current;
            }
        }
        else
        { 
            while((current = current.AddDays(7)).Month == month)
                yield return current;
        }
    }
