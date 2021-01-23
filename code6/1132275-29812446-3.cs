    Func<MenuItem, bool> predicate = x => megaMenuItems.Select(y => y.TabId).Contains(x.TabId);
    RootNode = RootNode.Children.Where(predicate)
        .Select(z => new MenuItem
        {
            Id = z.Id, PortalId = z.PortalId, TabId = z.TabId, 
            Children = z.Children == null ? null
                : z.Children.Where(predicate).ToList()
        })
        .ToList();
