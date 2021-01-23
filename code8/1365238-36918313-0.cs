    List<TreeViewItem> GetChildren(TreeViewItem parent)
    {
        List<TreeViewItem> children = new List<TreeViewItem>();
        if (parent != null)
        {
            foreach (var item in parent.Items)
            {
                TreeViewItem child = item as TreeViewItem;
          
                if (child == null)
                {
                    child = parent.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;
                }
                children.Add(child);
            }
        }
        return children;
    }
