    private static IList<Request> MergeRequests(IEnumerable<Request> requests)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var dateTimeFormatInfo = currentCulture.DateTimeFormat;
        Func<DateTime, int> curry = dt => currentCulture.Calendar.GetWeekOfYear(dt, dateTimeFormatInfo.CalendarWeekRule, dateTimeFormatInfo.FirstDayOfWeek);
        return requests.GroupBy(r => r.PersonId)
                        .SelectMany(personGroup =>
                        {
                            return personGroup.GroupBy(r => curry(r.StartDate)).Select(weekGroup => new Request
                            {
                                PersonId = personGroup.Key,
                                StartDate = weekGroup.Min(x => x.StartDate),
                                EndDate = weekGroup.Max(x => x.EndDate)
                            });
                        })
                        .ToList();
    }
