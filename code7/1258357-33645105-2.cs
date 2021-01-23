    List<List<int>> lists = new List<List<int>>
    {
        new List<int> { 1, 2, 3, 4 },
        new List<int> { 1, 3, 3, 3 },
        new List<int> { 1, 2, 2, 3 },
        new List<int> { 1, 1, 1, 1 }
    };
    lists = lists.OrderByDescending(x => x.GroupBy(g => g).Max(g => g.Count())).ToList();
    
