    var highestCount =  categoryGroups.OrderByDescending(g => g.Count())
         .Select(g => new { Category = g.Key, Count = g.Count() })
         .First();
    Console.WriteLine("Category:{0} Count:{1}", highestCount.Category, highestCount.Count);
 
