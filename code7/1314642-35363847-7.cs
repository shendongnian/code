    private static Boolean IsHoliday(DateTime value, IEnumerable<DateTime> holidays = null) {
      if (null == holidays)
        holidays = PortugueseHolidays;
    
      return (value.DayOfWeek == DayOfWeek.Sunday) ||
             (value.DayOfWeek == DayOfWeek.Saturday) ||
              holidays.Any(holiday => holiday.Day == value.Day && 
                                      holiday.Month == value.Month);
    }
