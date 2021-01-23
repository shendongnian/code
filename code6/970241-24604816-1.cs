    DependencyObject selectedRow = nextCell;
    while ((selectedRow != null) && !(selectedRow is DataGridRow))
    {
        selectedRow = VisualTreeHelper.GetParent(selectedRow);
    }
    if ((selectedRow as DataGridRow).Item.ToString() != "{NewItemPlaceholder}")
    {
        // start edit mode
        maindg.BeginEdit();
    }
