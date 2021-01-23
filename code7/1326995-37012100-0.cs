    <xcdg:DataGridCollectionViewSource AutoFilterValuesChanged="DataGrid_AutoFilterValuesChanged" ... />
    private void DataGrid_AutoFilterValuesChanged(object sender, AutoFilterValuesChangedEventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(UpdateViewModel), DispatcherPriority.Normal);
    }
    private void UpdateViewModel()
    {
        // your code here
    }
