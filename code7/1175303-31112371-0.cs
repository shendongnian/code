    private void AllFilesCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        var checkBoxes = GetAllCheckBoxes(files);
        foreach (var checkBox in checkBoxes)
        {
            // Do stuff with the CheckBoxes
        }
    }
    private List<CheckBox> GetAllCheckBoxes(ItemsControl itemsControl)
    {
        var list = new List<CheckBox>();
        foreach (var item in itemsControl.Items)
        {
            var itemContainer = files.ItemContainerGenerator.ContainerFromItem(item);
            var checkBox = itemContainer.GetChildOfType<CheckBox>();
            if (checkBox != null)
                list.Add(checkBox);
            if (itemContainer is ItemsControl)
                list.AddRange(GetAllCheckBoxes(itemContainer));
        }
    }
    public static T GetChildOfType<T>(this DependencyObject depObj) 
        where T : DependencyObject
    {
        if (depObj == null) return null;
    
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
    
            var result = (child as T) ?? GetChildOfType<T>(child);
            if (result != null) return result;
        }
        return null;
    }
