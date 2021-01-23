    private void DgDataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int newIndex = (sender as DataGrid).SelectedIndex / 2;
            if (Convert.ToInt32(newIndex) >= 1)
                (sender as DataGrid).SelectedItem = previous;
            else
            {
                previous = (sender as DataGrid).CurrentItem;
            }
        }
