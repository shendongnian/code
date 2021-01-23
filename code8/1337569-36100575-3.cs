    result.Content = pageResult
            .Select(a => new                    // This filters in the database
            {                                   // to an anonymous type
                Accepted = a.Accepted,
                Created = a.Created,
                Id = a.Id,
                ClientId = a.ClientId
            })
            .AsEnumerable()                     // Convert to an IEnumerable 
            .Select(a => new QuoteSearch        // This is done in-memory
            {                                   // generating the real type
                Accepted = a.Accepted,
                Created = a.Created,
                Id = a.Id,
                Customer = clients.Find(b => b.Id == a.ClientId).Name
            }).ToList();
