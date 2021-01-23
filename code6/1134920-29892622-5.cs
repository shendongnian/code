     var results = query.Select(DataSelectionQuery).ToList()
        .Select(p => new
        {
            p.ID,
            p.FirstName,
            p.LastName,
            TEST = dict.FirstOrDefault(q => q.Key == p.ID).Value.ToString()
        });
