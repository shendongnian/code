    var added = new List<int>();
    var removed = new List<int>();
    
    added.AddRange(list2.Where(i => !list1.Contains(i));
    removed.AddRange(list1.Where(i => !list2.Contains(i));
    var areIndentical = added.Count == 0 && removed.Count == 0;
