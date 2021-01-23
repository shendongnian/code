    using (var context = new ApplicationDbContext())
    {
        var allTables = context.GetAllDbSets();
        var allTablesInMemory = context.GetAllDbSets()
                     .Select(q => Enumerable.ToArray((dynamic)q))
                     .ToArray();
        var allValuesInArray = context.GetAllDbSets()
                     .SelectMany<dynamic,dynamic>(q => Enumerable.ToArray(q))
                     .ToArray();
    }
