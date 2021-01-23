    var result = new Dictionary<int, SortedList<int, List<int>><();
    foreach (var key1 in ddl1.Keys.Intersect(ddl2.Keys))
    {
        var subList1 = ddl1[key1];
        var subList2 = ddl2[key1];
        var common1 = new SortedList<int, List<int>>();
        result.Add(key1, common1);
        foreach (var key2 in subList1.Keys.Intersect(subList2.Keys))
        {
            var subList1L2 = subList1[key2];
            var subList2L2 = subList2[key2];
            var common2 = subList1L2.Intersect(subList2L2).ToList();
            if (common2.Count > 0) common1.Add(key2, common2);
        }
    }
