    var data = context.Database.SqlQuery<ViewModel>(query)
        .ToList() // Execute the query first
        .GroupBy(q => q.Id)
        .Select(g => new A
        {
            Id = g.Key,
            Data = g.Select(b => new B { Name = b.Name, Address = b.Address }).ToList()
        })
        .ToList();
