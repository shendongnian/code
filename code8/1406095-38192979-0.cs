    var highestCounts = pList.Values
                        .GroupBy(t => t.Item1)
                        .OrderByDescending(g => g.Count())  
                        .Select(g => new { Category = g.Key, Count = g.Count() })  
                        .Take(3)
                        .ToArray();
    
    // highestCounts[0] is the first count
    // highestCounts[1] is the second
    // highestCounts[2] is the third
    // make sure to handle cases where there are less than 3 items!
