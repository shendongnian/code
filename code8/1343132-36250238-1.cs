    public List<MyClass> SortHierarchically(IEnumerable<MyClass> myClasses)
    {
        if(myClasses == null)
            return new List<MyClass>();
        var myClassesByParentId = myClasses.ToLookup(mc => mc.ParentId);
        var result = new List<MyClass>(myClasses.Count());
        
        int? currentParentId = null;
        MyClass currentItem = myClassesByParentId[currentParentId].Single();
        result.Add(currentItem);
        currentParentId = currentItem.Id;
        if(myClassesByParentId.Contains(currentParentId))
            result.AddRange(myClassesByParentId[currentParentId].SelectMany(mc => GetAllSortedChildren(mc, myClassesByParentId)));  
        return result;
    }
    public List<MyClass> GetAllSortedChildren(MyClass parent, ILookup<int?, MyClass> myClassesByParentId)
    {
        var result = new List<MyClass>() { parent };
        if(myClassesByParentId.Contains(parent.Id))
            retsult.AddRange(myClassesByParentId[parent.Id].SelectMany(mc => GetAllSortedChildren(mc, myClassesByParentId)));
        return result;
    }
