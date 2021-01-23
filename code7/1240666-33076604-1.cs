    private void DatagridExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        DataGridCell cell = e.OriginalSource as DataGridCell;
        if (cell != null)
        {
            Product product = cell.DataContext as Product;
            if (product != null)
            {
                Clipboard.SetText(product.SerialNumberId);
            }
        }
    }
