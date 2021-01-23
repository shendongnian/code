    // Select distinct names as in first case
    var names = list.Select(t => t.Name.ToLower()).Distinct().ToList();
    // Construct listNew from names based on same algorithm as before, but using LINQ this time.
    var listNew = names
        .Select(name => list.Where(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                            .OrderByDescending(t => t.VerMajor)
                            .ThenByDescending(t => t.VerMinor)
                            .FirstOrDefault())
        .Where(item => item != null)
        .ToList();
     // Here, listNew contains your desired result.
