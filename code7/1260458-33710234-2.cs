    while (theList[0].IsActive && theList[theList.Count-1].IsActive)
    {
        theList.RemoveAt(0);
        theList.RemoveAt(theList.Count-1);
    }
