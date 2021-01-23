    // returns a Dictionary<string, List<string>>
    var groupByEmployee = rowsDictionary
        .SelectMany(kvp => kvp.Value)
        .GroupBy(s => s.LastName.ToUpper() + s.FirstName.ToUpper())
        .ToDictionary(
             s => s.Key,
             s => s.Select(x => x.Delivery_System).Distinct().ToList());
