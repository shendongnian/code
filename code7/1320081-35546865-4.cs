    static bool IsParent(IEnumerable<InputClass> lc, InputClass ic, int? ParentID)
    {
        return ic.parentId != null ? ic.parentId == ParentID || IsParent(lc, lc.First(o => o.id == ic.parentId), ParentID) : false;
    }
    int? id = 1; // Parent ID
    foreach(var i in inputList)
    {
        if(IsParent(inputList, i, id)))
        {
            // get this item
        }
    }
