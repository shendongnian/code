    // First GroupBy compound type
    .GroupBy(i => new { i.Type, i.Year })
    // Then select from the Group Key and
    // apply an Aggregate/query on the Grouped Values
    .Select(g => new {
       Type = g.Key.Type,         // Pull out key values
       Year = g.Key.Year,
       Cost = g.Sum(i => i.Cost)  // Sum all items in group
    })
