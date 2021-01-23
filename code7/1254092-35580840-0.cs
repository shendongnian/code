    private void propertyGrid_PreparePropertyItem(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyItemEventArgs e)
    {
        var item = e.Item as Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem;
        if (item == null)
            return;
        if (!item.PropertyType.IsValueType && item.PropertyType != typeof(string))
        {
            e.PropertyItem.IsExpandable = true;
        }
    }
