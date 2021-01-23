    var data = new List<SomeEntity>().AsQueryable()
        .GroupBy(p => new
        {
            p.Date.Month,
            p.Name
        }).Select(p => new SomeDto
        {
            Month = p.Key.Month,
            Name = p.Key.Name,
            TotalPrice = p.Sum(entity => entity.Price)
        })
       .ToList();
