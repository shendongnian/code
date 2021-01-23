    public bool TheCondition(MyEntity parent, MyEntity child)
    {
        return parent.W_ID == child.W_ID 
            && (parent.ValueOfW == child.ValueOfW || parent.ValueOfW == 0)
    }
    public bool ChildMatchesAnyParent(MyEntity child, IEnumerable<MyEntity> parents)
    {
        return parents.Any(parent => TheCondition(parent, child);
    }
    var selected = childList.Where(child => ChildMatchesAnyParent(child, parentList));
    var ids = selected.Select(entity => entity.ID).ToList();
