    private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
    {
        var currentRowIndex = URLGRID.Items.IndexOf(URLGRID.selectedItem);
        {
            if (URLGRID.selectedItem != null)
            {
                WindowMail wm = new WindowMail();
                wm.Show();
            }
        }
    }
