    // Start with the customers collection
    var mostCommonAge = customers
    // then group by their age, 
        .GroupBy(c => c.Age,
    // and project into a new anonymous type
            (key, g) => new {Age = key, Count = g.Count()})
    // order by count of each age
        .OrderByDescending(g => g.Count)
    // and take the first
        .First();
