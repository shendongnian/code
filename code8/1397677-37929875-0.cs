        var result = clients
                        .GroupBy(c => c.Id)
                        .Select(g => new { Id = g.Key, FromDate = g.Min(c => c.FromDate) });
        var result = from c in clients
            group c by new { id = c.Id } into g
            select new { id = g.Key, FromDate = g.Min(c => c.FromDate) };
