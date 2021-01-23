    var itemCounts = itemStrings.GroupBy(x => x)
        .ToDictionary(g => g.Key, g => g.Count());
    string result = String.Join(", ", 
        itemCounts.Select(kv => kv.Value > 1 
            ? string.Format("{0} ({1} times)", kv.Key, kv.Value) 
            : kv.Key)); 
