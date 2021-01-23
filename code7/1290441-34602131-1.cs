    private static IList<Request> MergeRequests(IEnumerable<IGrouping<int, Request>> groupedByPerson)
    {
        return groupedByPerson
            .Select(@group => new Request
            {
                PersonId = @group.Key,
                StartDate = @group.Min(x => x.StartDate),
                EndDate = @group.Max(x => x.EndDate)
            })
            .ToList();
    }
