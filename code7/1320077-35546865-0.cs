    static bool IsParent(List<InputClass> lc, InputClass ic, int ParentID)
    {
        return ic.parentId != null ? ic.parentId == ParentID || IsParent(lc, lc.First(o => o.id == ic.parentID), ParentID) : false;
    }
    int id = 1; // Parent ID
    foreach(var i in inputList)
    {
        if(i.parentId != null && (i.parentId == id || IsParent(inputList, i, id)))
        {
            // get this item
        }
    }
