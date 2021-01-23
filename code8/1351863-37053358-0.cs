    private void btnCollapseAllGroups_ButtonClick(object sender, RoutedEventArgs e)
    {
        CollapseOrExpandAll(null, true);
    }
    private void btnExpandAllGroups_ButtonClick(object sender, RoutedEventArgs e)
    {
        CollapseOrExpandAll(null, false);
    }
    private void CollapseOrExpandAll(CollectionViewGroup inputGroup, Boolean bCollapseGroup)
    {
        IList<Object> groupSubGroups = null;
        // If top level then inputGroup will be null
        if (inputGroup == null)
        {
            if (grid.Items.Groups != null)
                groupSubGroups = grid.Items.Groups;
        }
        else
        {
           groupSubGroups = inputGroup.GetItems();
        }
        if (groupSubGroups != null)
        {
            
            foreach (CollectionViewGroup group in groupSubGroups)
            {
                // Expand/Collapse current group
                if (bCollapseGroup)
                    grid.CollapseGroup(group);
                else
                    grid.ExpandGroup(group);
                // Recursive Call for SubGroups
                if (!group.IsBottomLevel)
                    CollapseOrExpandAll(group, bCollapseGroup);
            }
        }
    }
