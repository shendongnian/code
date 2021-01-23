    int ix = 0;
    while (theList[ix].IsActive)
    {
        ++ix;
    }
    
    // copy remaining items to the front
    int dest = 0;
    if (ix > 0)
    {
        for (int i = ix; i < theList.Count-1; ++i)
        {
            theList[dest] = theList[i];
            ++dest;
        }
        // and remove the last ix items from the end
        while (ix > 0)
        {
            theList.RemoveAt(theList.Count-1);
            --ix;
        }
    }
