    int lastItem = theList.Count-1;
    while (theList.Count > 0 && theList[lastItem].IsActive)
    {
        lastItem = lastItem - 1;
    }
    int firstItem = 0;
    while (theList[firstItem].IsActive)
    {
        ++firstItem;
    }
    // copy items to create a new list
    theList = theList.Skip(firstItem)
        .Take(lastItem - firstItem)
        .ToList();
