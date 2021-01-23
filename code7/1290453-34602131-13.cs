    private static IList<Request> MergeRequests(IEnumerable<Request> requests)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var dateTimeFormatInfo = currentCulture.DateTimeFormat;
        Func<DateTime, int> weekDay = dt => currentCulture.Calendar.GetWeekOfYear(dt, dateTimeFormatInfo.CalendarWeekRule, dateTimeFormatInfo.FirstDayOfWeek);
        return requests.GroupBy(r => Tuple.Create(r.PersonId, weekDay(r.StartDate)))
                        .Select(weekGroup => new Request
                        {
                            PersonId = weekGroup.Key.Item1,
                            StartDate = weekGroup.Min(x => x.StartDate),
                            EndDate = weekGroup.Max(x => x.EndDate)
                        })
                        .ToList();
    }
