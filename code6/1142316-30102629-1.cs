    var lists = new[] { list1, list2, ..., listN }; // dynamically specified
    var common = lists.First().AsEnumerable();
    foreach (var list in lists.Skip(1))
    {
        common = common.Intersect(list);
    }
    // and now common has the result, e.g.
    var listOfCommonEntries = common.ToList();
