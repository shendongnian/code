    //select your grouped results
    var retVal = readModel
            .GroupBy("Service", "it")
            .Select("new (it.key as GroupName, Sum(it.NumberOfItems) as GroupItems)");
    
    //Map them
    List<GroupView> res = new List<GroupView>();
    foreach (var val in retVal)
    {
        res.Add(new GroupView { GroupName = ((dynamic)val).GroupName, GroupItems = ((dynamic)val).GroupItems });
    }
