    List<List<int>> returnList = new List<List<int>>();
    foreach (var item in initList)
    {
        if (returnList.Where(p => !p.Except(item).Any() && !item.Except(p).Any()
                                 && p.Count() == item.Count() ).Count() == 0)
        returnList.Add(item);
    }
