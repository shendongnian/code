    public void GetUsallyOpeningClosingHour(
        Func<OpeningDay, TimeSpan> groupByRule, 
        bool orderByDesc = false)
    {
        var groupedDays = listOfSpecificDayOfWeek.GroupBy(groupByRule);
        var openingClosingHours =
            orderByDesc
                ? groupedDays.OrderByDescending(x => x.Key)
                : groupedDays.OrderBy(x => x.Key);
    }
