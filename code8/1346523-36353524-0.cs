    var list1 = new List<string> {"X", "W", "C", "A", "D", "B"};
    var list2 = new List<string> {"A", "B", "C", "D"};
    var newList = list1.OrderBy(x =>
    {
        var index = list2.IndexOf(x);
        if (index == -1)
            index = Int32.MaxValue;
        return index;
    })
    .ToList();
