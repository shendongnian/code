    List<int> b = new List<int>() { 1,2,4,8,289 };
    List<int> a = new List<int>() { 2,2,56,2,4,33,4,1,8 };
    
    var subset = a.Where(i => b.Contains(i));
    var count = subset.Count(); // 7
    var sum = subset.Sum();  // 23
    
