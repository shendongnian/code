    // First create new list that would hold the results
    var listNew = new List<VerX>();
    // Select distinct names from data (using ToLower, so casing does not matter)
    var names = list.Select(t => t.Name.ToLower()).Distinct().ToList();
    // Loop through each of distinct name
    foreach (var name in names)
    {
        // With LINQ, select item whose name matches and sort list by VerMajor
        // descending and VerMinor descending and take first item.
        var item = list.Where(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                       .OrderByDescending(t => t.VerMajor)
                       .ThenByDescending(t => t.VerMinor)
                       .FirstOrDefault();
        // If item not found (although it should be found!), continue the loop
        if (item == null)
            continue;
        // Add item to new list
        listNew.Add(item);
    }
    // At the end of the loop, the listNew contains items as in your proposed result.
