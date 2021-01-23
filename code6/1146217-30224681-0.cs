    List<ClassWithProperties> mylist = GetList();
    var selected = mylist.Where(s => s.NeedsShowing.HasValue && s.NeedsShowing.Value);
    var children = mylist.Where(c => c.ParentID.HasValue && selected.Select(s => s.ID).Contains(c.ParentID.Value));
    while (children.Any())
    {
        var childChild = mylist.Where(c => c.ParentID.HasValue && children.Select(s => s.ID).Contains(c.ParentID.Value));
        selected = selected.Union(children);
        children = childChild;
    }
