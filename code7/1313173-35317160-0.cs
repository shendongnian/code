    context.Parents.Include(p => p.Children).AsEnumerable()
    .Select(p => new {
        Id = p.Id,
        Name = p.Name,
        Children = p.Children.Select(c => new {
            Id = c.Id,
            Name = c.Name
        })
    }).ToList();
