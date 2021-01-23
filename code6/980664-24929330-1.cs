    var userCreditsGroup = addedStatistics
        .Where(w => w.User != null)
        .GroupBy(g => g.User.Id)
        .Select(s => new
        {
            User = s.Value.First().User,
            Count = s.Sum(p=>p.Api.CreditCost)
        })
        .ToList();
