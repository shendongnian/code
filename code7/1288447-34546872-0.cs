    foreach (var group in results)
    {
        // This will get the parentId value in the group.
        var parentId = group.Key;
        // This will get all the Ids contained in the group.
        foreach (var Id in group)
        {
            // Do something with Id. If something goees wrong
            // and you want to proceed with the next group,
            // just put a break; inside this foreach.
        }
    }
