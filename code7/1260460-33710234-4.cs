    // Remove all active items from the end
    while (theList.Count > 0 && theList[theList.Count-1].IsActive)
    {
        theList.RemoveAt(theList.Count-1);
    }
    // determine how many items you have to remove from the front
    int ix = 0;
    while (theList[ix].IsActive)
    {
        ++ix;
    }
    // ix now says how many items need to be removed from the start
    if (ix > 0)
    {
        int dest = 0;
        int end = theList.Count - ix;
        // copy items to overwrite the removed ones
        for (int i = ix; i < end; ++i)
        {
            theList[dest] = theList[i];
            ++dest;
        }
        // and remove items from the end
        while (ix > 0)
        {
            theList.RemoveAt(theList.Count-1);
            --ix;
        }
    }
