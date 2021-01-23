            DependencyObject dep = (DependencyObject)e.OriginalSource; 
            var cell = dep as System.Windows.Controls.DataGridCell;
            while ((dep != null) && !(dep is DataGridRow))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            var row = dep as DataGridRow;
            if (row != null)
            {
                var dataGrid = ItemsControl.ItemsControlFromItemContainer(row) as System.Windows.Controls.DataGrid;
                return dataGrid;
            }
