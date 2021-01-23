    private void DataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        var dataGrid = (DataGrid)sender;
        if (dataGrid.IsGrouping && e.HorizontalChange != 0.0)
        {
            TraverseVisualTree(dataGrid, e.HorizontalOffset);
        }
    }
    
    private void TraverseVisualTree(DependencyObject reference, double offset)
    {
        var count = VisualTreeHelper.GetChildrenCount(reference);
        if (count == 0)
            return;
    
        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(reference, i);
            if (child is ToggleButton)
            {
                var toggle = (ToggleButton)child;
                toggle.Margin = new Thickness(offset, 0, 0, 0);
            }
            else
            {
                TraverseVisualTree(child, offset);
            }
        }
    }
