    var collection1 = "testtt".GroupBy(c => c).Select(g => new { Key = g.Key, Count = g.Count() });
    var collection2 = "teessst".GroupBy(c => c).Select(g => new { Key = g.Key, Count = g.Count() });
    var result = collection1.Concat(collection2)
        .GroupBy(item => item.Key, item => item.Count)
        .Select(g => new { Key = g.Key, Count = g.Max() });
 
