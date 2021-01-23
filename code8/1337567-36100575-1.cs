    result.Content = pageResult
            .AsEnumerable()
            .Select(a => new QuoteSearch
            {
                Accepted = a.Accepted,
                Created = a.Created,
                Id = a.Id,
                Customer = clients.Find(b => b.Id == a.ClientId).Name
            }).ToList();
