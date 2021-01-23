    private void FindAllChildren()
    {
        var depObj = dataGrid;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
            if (child is DataGridTemplateColumn)
            {
                // do a thing
            }
        }
    }
