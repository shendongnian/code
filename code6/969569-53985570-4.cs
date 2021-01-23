    result.GroupBy(i => i.Memberid.ToString() + i.Name).Select(g => new
    { 
        Name = g.FirstOrDefault().Name,
        Amount = g.Sum(x => double.Parse(x.Amount))
    }).ToList();
