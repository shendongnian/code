    // Remove current Copy command
    int index = 0;
    foreach (CommandBinding item in this.myGrid.CommandBindings)
    {
        if (((RoutedCommand)item.Command).Name == "Copy")
        {
            this.myDataGrid.CommandBindings.RemoveAt(index);
	        break;
        }
        index++;
    }
    // Add new Copy command
    this.myDataGrid.CommandBindings.Add(xceedCopyCommandBinding);
