        private void DataGridCell_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                var parent = VisualTreeHelper.GetParent(cell);
                while (parent != null && parent.GetType() != typeof(DataGrid))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }
                DataGrid dGrid = parent as DataGrid;
                dGrid.BeginEdit();
            }
        }
