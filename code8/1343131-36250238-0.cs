    public List<MyClass> SortHierarchically(IEnumerable<MyClass> myClasses)
    {
        if(myClasses == null)
            return new List<MyClass>();
        var myClassByParentId = myClasses.ToDictionary(mc => mc.ParentId);
        var result = new List<MyClass>(myClasses.Count());
        int? currentParentId = null;
        MyClass currentItem;
        while(myClassByParentId.TryGet(currentParentId, out currentItem))
        {
            result.Add(currentItem);
            currentParentId = currentItem.Id;
        }
        return result;
    }
