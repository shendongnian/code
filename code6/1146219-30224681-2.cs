    List<FileHierarchy> mylist = GetList();
    var selected = mylist.Where(s => s.NeedsShowing.HasValue && s.NeedsShowing.Value);
    var children = mylist.Where(c => c.ParentID.HasValue && selected.Select(s => s.ID).Contains(c.ParentID.Value));
    var unselected = mylist.Except(selected);
    while (children.Any())
    {
        unselected = unselected.Except(children);
        var childChild = unselected.Where(c => c.ParentID.HasValue && children.Select(s => s.ID).Contains(c.ParentID.Value));
        selected = selected.Union(children);
        children = childChild;
    }
