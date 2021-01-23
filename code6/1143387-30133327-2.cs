    dbContext.Stores.Select(s => new Contact 
        {
            ID = s.ID,
            Name = s.Name,
            Phone = s.Phone,
            Type = "Store",
        })
        .Union(dbContext.Persons.Select(p => new Contact 
        {
            ID = p.ID,
            Name = p.Name,
            Phone = p.Phone,
            Type = "Person",
        }));
