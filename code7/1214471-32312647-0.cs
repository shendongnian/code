    var tmpDict = ExistingList.ToDictionary(x => x.FileName);
    foreach (var item in UpdatedList)
    {
        tmpDict[item.FileName] = item;
    }
    var newList = tmpDict.Select(x => x.Value).OrderByDescending(c => c.LastModified).ToList();
