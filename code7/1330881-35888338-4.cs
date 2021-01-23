    foreach (string groupidListItem in groupidList)
    {
        var mylist = list
           .Where(item => **item.ITEMGROUP**.Contains(groupidListItem))
           .ToList();
        grouped.AddRange(mylist);
    }
    list = grouped;
    return list;
