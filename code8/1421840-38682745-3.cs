    var list1 = new List<int> { 1 };
    var list2 = new List<int> { 1, 2 };
    var lists = new[] { list1, list2 };
    
    // Non caching usage
    foreach (var combination in lists.GenerateCombinations())
    {
    	// do something with the combination
    }
    
    // Caching usage
    var combinations = lists.GenerateCombinations().Select(c => c.ToList()).ToList();
