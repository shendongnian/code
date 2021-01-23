    RootNode.Children.RemoveAll(x => megaMenuItems.All(y => y.TabId != x.TabId));
    foreach (MenuItem node in RootNode.Children)
    {
        if (node.Children != null)
        {
            node.Children.RemoveAll(x => megaMenuItems.All(y => y.TabId != x.TabId));
        }
     }
