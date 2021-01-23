    public static int BusinessDaysUntil(this DateTime fromDate, 
                                        DateTime toDate,
                                        IEnumerable<DateTime> holidays = null) {
      int result = 0;
    
      for (DateTime date = fromDate.Date; date < toDate.Date; date = date.AddDays(1))
        if (!IsHoliday(date, holidays))
          result += 1;
    
      return result;
    }
