    private static IList<Request> MergeRequests(IEnumerable<Request> groupedByPerson)
    {
        Func<DateTime, int> curry = dt => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        return groupedByPerson.GroupBy(r => curry(r.StartDate))
                              .SelectMany(@group =>
                              {
                                  return @group.GroupBy(r => r.PersonId).Select(z => new Request
                                  {
                                      PersonId = z.Key,
                                      StartDate = @group.Min(x => x.StartDate),
                                      EndDate = @group.Max(x => x.EndDate)
                                  });
                              })
                              .ToList();
    }
