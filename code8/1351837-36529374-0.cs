     private void ItemsView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            var index = dg.SelectedIndex;
            //here we get the actual row at selected index
            DataGridRow row = dg.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            
            //here we get the actual data item behind the selected row
            var item = dg.ItemContainerGenerator.ItemFromContainer(row);
        }
