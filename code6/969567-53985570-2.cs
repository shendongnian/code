    result.GroupBy(i => New With {Key i.Memberid, Key i.Name}).Select(g => new
    { 
        Name = g.FirstOrDefault().Name,
        Amount = g.Sum(x => double.Parse(x.Amount))
    }).ToList();
