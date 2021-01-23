    // Get collection
    var collection = _database.GetCollection<VehicleDataUpload>("Vehicles");
    
    // Get first project that meets our identifier
    var aggregation = collection
        .AsQueryable()
        // This will return an IEnumerable of Vehicles object
        .Where(i => i.ProjectId.Equals("1234"))
        // Assuming you want to return a plain list, you should use SelectMany
        .SelectMany(v => v.VehicleEntries
            // You group each list of VehicleEntries
            .GroupBy(ve => ve.Data)
            // For each group you return a new DailySummaryData object
            .Select(g => new DailySummaryData() {
                ProjectName = v.ProjectId,
                Date = g.Key,
                Passed = g.Sum(x => (x.VehicleStatus.Equals("PASSED") ? 1 : 0)),
                Failed = g.Sum(x => (x.VehicleStatus.Equals("FAILED") ? 1 : 0))
            })
    return aggregation.ToList();
