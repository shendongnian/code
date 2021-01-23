            // List of items from the datagrid
            var itemsSource = dgv_RStructure.ItemsSource as IList;
            // if such items exist
            if (itemsSource != null)
            {
                // Get each item as a datagrid row based on a selected index.
                var row = dgv_RStructure.ItemContainerGenerator.ContainerFromItem(itemsSource[int.Parse(id)]) as DataGridRow;
                // if the selected Datagrid Row exists
                if (row != null)
                {
                    // change the row background to the preferred color.
                    row.Background = Your_SolidColorBrush;
                }
            }
