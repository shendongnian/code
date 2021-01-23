    public [return-type] GetUsallyOpeningClosingHour(Func<OpeningDay, TimeSpan> groupByRule, bool isAscending)
    {
        var openingClosingHours = listOfSpecificDayOfWeek.GroupBy(groupByRule);
        if (isAscending)
        {
            openingClosingHours = openingClosingHours.OrderBy(x => x.Key);
        }
        else
        {
            openingClosingHours = openingClosingHours.OrderByDescending(x => x.Key);
        }
        // Return openingClosingHours?  It's not clear how you're using this variable.
    }
