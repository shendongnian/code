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
            var itemContainer = itemsControl.ItemContainerGenerator.ContainerFromItem(item);
            var checkBox = itemContainer.GetChildOfType<CheckBox>();
            if (checkBox != null)
                list.Add(checkBox);
            if (itemContainer is ItemsControl)
                list.AddRange(GetAllCheckBoxes(itemContainer));
        }
        return list;
    }
