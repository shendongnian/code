    private static IList<Request> MergeRequests(IEnumerable<Request> groupedByPerson)
    {
        return groupedByPerson.GroupBy(r => r.PersonId)
                              .Select(@group => new Request
                              {
                                  PersonId = @group.Key,
                                  StartDate = @group.Min(x => x.StartDate),
                                  EndDate = @group.Max(x => x.EndDate)
                              })
                              .ToList();
    }
