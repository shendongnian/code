    TheDataGrid.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(TheDataGrid_PreviewMouseLeftButtonDown);
    
    
    void TheDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // get the DataGridRow at the clicked point
        var o = TryFindFromPoint<DataGridRow>(TheDataGrid, e.GetPosition(TheDataGrid));
        // only handle this when Ctrl or Shift not pressed 
        ModifierKeys mods = Keyboard.PrimaryDevice.Modifiers;
        if (o != null && ((int)(mods & ModifierKeys.Control) == 0 && (int)(mods & ModifierKeys.Shift) == 0))
        {
            o.IsSelected = !o.IsSelected;
            e.Handled = true;
        }
    }
