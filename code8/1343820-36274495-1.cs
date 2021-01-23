    DateTime dt = Convert.ToDateTime(filterDate);
    var query = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, dt);
    var query2 = TableQuery.CombineFilters(query,
            TableOperators.And, 
            TableQuery.GenerateFilterConditionForDate("Timestamp",    QueryComparisons.LessThan, dt.AddDays(1)));
