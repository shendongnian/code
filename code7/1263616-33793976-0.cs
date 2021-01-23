    var promotions = new List<Promotion>();
    promotions.Add(new Promotion { Id = 1, Amount = 2, StartDate = new DateTime(2015, 10, 14), EndDate = new DateTime(2015, 12, 31) });
    promotions.Add(new Promotion { Id = 1, Amount = 3, StartDate = new DateTime(2015, 11, 01), EndDate = new DateTime(2015, 11, 15) });
    promotions.Add(new Promotion { Id = 3, Amount = 10, StartDate = new DateTime(2015, 11, 01), EndDate = new DateTime(2015, 12, 01) });
    promotions.Add(new Promotion { Id = 5, Amount = 32, StartDate = new DateTime(2015, 11, 01), EndDate = new DateTime(2015, 12, 01) });
    promotions = promotions.GroupBy(p => p.Id).Select(p => new Promotion
        {
            Id = p.Key,
            Amount = p.Sum(i => i.Amount),
            StartDate = p.Min(i => i.StartDate),
            EndDate = p.Min(i => i.EndDate)
    }).ToList();
