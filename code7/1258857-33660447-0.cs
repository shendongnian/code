    var DatesThisYesr =
        Enumerable.Range(1, 12)
        .SelectMany(month =>
            Enumerable.Range(1, DateTime.DaysInMonth(intCurrentYear, month))
            .Select(day => new DateTime(intCurrentYear, month, day)))
        .ToList();
