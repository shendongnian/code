    public static void GetUsallyOpeningClosingHour(
        Func<OpeningDay, TimeSpan> groupByRule,
        Func<IEnumerable<IGrouping<TimeSpan, OpeningDay>>,
             IEnumerable<IGrouping<TimeSpan, OpeningDay>>> orderBy)
    {
        var groupedDays = listOfSpecificDayOfWeek.GroupBy(groupByRule);
        var openingClosingHours = orderBy(groupedDays);
    }
