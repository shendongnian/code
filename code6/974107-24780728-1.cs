        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var cell = e.OriginalSource as DataGridCell;
                if (cell != null)
                {
                    var dataitem = cell.DataContext;  //Here you can you AS keyword to convert the DataContext to your item type.
                    //dataitem.FirstName
                }
            }
        }
