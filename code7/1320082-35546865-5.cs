    static IEnumerable<InputClass> getAllChildren(IEnumerable<InputClass> lc, int? ParentID)
    {
        foreach (var i in lc)
        {
            if (i.parentId == ParentID)
            {
                yield return i;
                foreach (var i2 in getAllChildren(lc, i.id)) yield return i2;
            }
        }
    }
    int? id = 1; // Parent ID
    foreach (var i in getAllChildren(inputList,id))
    {
        // Get this Item
    }
