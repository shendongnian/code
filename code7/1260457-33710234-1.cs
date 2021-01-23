    int ix = 0;
    while (theList[ix].IsActive && theList[theList.Count-ix-1].IsActive)
    {
        ++ix;
    }
    // ix now says how many items need to be removed from the start and end
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
        }
    }
