    // returns a Dictionary<EmployeeSummary, List<string>>
    // which maps each distinct EmployeeSummary into a list of
    // distinct delivery systems
    var groupByEmployee = rowsDictionary
        .SelectMany(kvp => kvp.Value)
        .GroupBy(s => s, new EmployeeSummaryEqualityComparer())
        .ToDictionary(
             s => s.Key, 
             s => s.Select(x => x.Delivery_System).Distinct().ToList());
