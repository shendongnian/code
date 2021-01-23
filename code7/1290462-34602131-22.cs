    private static IList<Request> MergeRequests(IEnumerable<Request> requests)
    {
        return requests.GroupBy(r => r.PersonId)
                        .Aggregate(new Stack<Request>(), (list, grouping) =>
                        {
                            foreach (var request in grouping.OrderBy(r => r.StartDate))
                            {
                                var peek = list.Any() ? list.Peek() : null;
                                if (peek?.EndDate.Date.Day + 1 == request.StartDate.Date.Day)
                                    peek.EndDate = request.EndDate;
                                else
                                    list.Push(request);
                            }
                            return list;
                        })
                        .OrderBy(x => x.PersonId).ThenBy(x => x.StartDate)
                        .ToList();
    }
