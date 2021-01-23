    private void dg_CurrentCellChanged(object sender, EventArgs e)
    {
        var dataGrid = sender as DataGrid;
        dataGrid.CommitEdit();
        Dispatcher.BeginInvoke(new Action(() => dataGrid.BeginEdit()), System.Windows.Threading.DispatcherPriority.Loaded);
    }
    private void DatePicker_Loaded(object sender, RoutedEventArgs e)
    {
        Keyboard.Focus(sender as DatePicker);
    }
