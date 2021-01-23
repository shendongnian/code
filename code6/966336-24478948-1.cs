    public bool IsSecondSaturdayInMonth(int year, int month, int day)
    {
        // 2nd Saturday cannot be before the 8th day or after 14th of the month...
        if (day < 8 || day > 14)
        {
          return false;
        }
        DateTime date = new DateTime(year, month, day);
        return date.DayOfWeek == DayOfWeek.Saturday;
     }
