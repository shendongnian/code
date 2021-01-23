    result.Content = pageResult.Select(a =>   
    {
        Accepted = a.Accepted,            // First select to temporary objects
        Created = a.Created,
        Id = a.Id,
        ClientId = a.ClientId
    }).
    AsEnumerable().                       // Move from EF to in memory linq
    Select(a => new QuoteSearch {         // for the rest of the query
        Accepted = a.Accepted,
        Created = a.Created,
        Id = a.Id,
        Customer = clients.Find(b => b.Id == a.ClientId).Name
    }).ToList();
