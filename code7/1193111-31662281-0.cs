    static void GetUsallyOpeningClosingHour(
      Func<OpeningDay, TimeSpan> groupByRule, 
      Func<IEnumerable<IGrouping<TimeSpan, OpeningDay>>, 
           Func<IGrouping<TimeSpan, OpeningDay>, TimeSpan>,
           IOrderedEnumerable<IGrouping<TimeSpan, OpeningDay>>> order)
    {
      IEnumerable<OpeningDay> listOfSpecificDayOfWeek = null;
      var openingClosingHours = order(listOfSpecificDayOfWeek.GroupBy(groupByRule), x => x.Key);
    }
