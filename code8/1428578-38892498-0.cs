    var StockGroupList = data
        ... // Should be type IEnumerable<List<History>>
        .ToList();
=> 
    var StockGroupList = data 
        .Select( x => x.ToList()) // Should be ordered by Date
        .ToList();
