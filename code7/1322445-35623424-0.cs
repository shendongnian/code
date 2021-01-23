    List<UserTransactionReport> result = 
        ...
        .Select(x => new UserTransactionReport
        {
           UserId = x.Key.UserId,
           ProjectId = x.Key.ProjectId,
           CreateTime = x.Key.CreateTime,
           TotalMinutesSpent = x.Sum(z => z.MinutesSpent)
        }).ToList();
