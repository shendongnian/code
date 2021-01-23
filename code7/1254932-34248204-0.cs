    private void PropertyGrid_SelectedObjectChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        var grid = sender as PropertyGrid;
        foreach (PropertyItem prop in grid.Properties)
        {
            if (prop.IsExpandable) //Only expand things marked as Expandable, otherwise it will expand everything possible, such as strings, which you probably don't want.
            {
                prop.IsExpanded = true; //This will expand the property.
                prop.IsExpandable = false; //This will remove the ability to toggle the expanded state.
            }
        }
    }
