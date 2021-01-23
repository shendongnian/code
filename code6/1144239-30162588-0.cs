    var theBsById = listB.GroupBy(b => b.Id);
    foreach(IGrouping<int, B> grouping in theBsById)
    {
        A theA = listA.Where(a => a.Id == grouping.Key).FirstOrDefault();
        if (theA != null)
        {
            theA.listofB = grouping.ToList();
        }
    }
