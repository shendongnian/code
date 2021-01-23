        public class EDataGridCellFocus
    {
        public static object GetFocusedCell(DependencyObject obj)
        {
            return obj.GetValue(IsFocusedProperty);
        }
        public static void SetFocusedCell(DependencyObject obj, object value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
             "FocusedCell", typeof(object), typeof(EDataGridCellFocus),
             new UIPropertyMetadata(false, null, OnCoerceValue));
        private static object OnCoerceValue(DependencyObject d, object baseValue)
        {
            if (((DataGrid)d).Items.Count > 0 || ((DataGrid)d).HasItems)
            { 
                var row = ((DataGrid)d).ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
                if (row != null)
                {
                    var cell = ((DataGrid)d).GetCell(baseValue[0], baseValue[1]);
                    
                        Keyboard.ClearFocus();
                        FocusManager.SetIsFocusScope(d, true);
                        FocusManager.SetFocusedElement(cell, cell);
                        Keyboard.Focus(cell);                    
                }
            }
            return baseValue;
        }
    }
     public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int columnIndex = 0)
        {
            if (row == null) return null;
            var presenter = row.FindVisualChild<DataGridCellsPresenter>();
            if (presenter == null) return null;
            var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            if (cell != null) return cell;
            // now try to bring into view and retreive the cell
            grid.ScrollIntoView(row, grid.Columns[columnIndex]);
            cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            return cell;
        }
        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        public static childItem FindVisualChild<childItem>(this DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }
