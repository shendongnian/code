    Table1.Select (t1 => 
        new
        {
            Id = t1.Id,
            Name = t1.Name,
            Date = t1.Date
        }
    ).Concat(
    Table2.Select (t2 => 
        new
        {
            Id = t2.Id,
            Name = t2.Name,
            Date = t2.Date
        }
    ))
    .OrderByDescending (x => x.Date).Take(5)
