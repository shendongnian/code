    public class DataGridCell : System.Windows.Controls.DataGridCell
    {
        static DataGridCell()
        {
            EventManager.RegisterClassHandler(typeof(DataGridCell), 
                UIElement.MouseLeftButtonDownEvent, 
                new MouseButtonEventHandler(DataGridCell.OnAnyMouseLeftButtonDownThunk), true);
        }
    
        private static void OnAnyMouseLeftButtonDownThunk(object sender, MouseButtonEventArgs e)
        {
            ((DataGridCell)sender).OnAnyMouseLeftButtonDown(e);
        }
    
        private void OnAnyMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            bool isKeyboardFocusWithin = base.IsKeyboardFocusWithin;
            bool flag = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
            DataGrid dataGridOwner = ReflectionHelper.GetPropertyValue<DataGrid>(this, "DataGridOwner");
            if (isKeyboardFocusWithin && !flag && !e.Handled && this.IsSelected)
            {
                if (dataGridOwner != null)
                {
                    ReflectionHelper.Execute(dataGridOwner, "HandleSelectionForCellInput",
                        this, false, true, false);
    
                    if (!this.IsEditing && !this.IsReadOnly)
                    {
                        dataGridOwner.BeginEdit(e);
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (!isKeyboardFocusWithin || !this.IsSelected || flag)
            {
                if (!isKeyboardFocusWithin)
                {
                    base.Focus();
                }
                if (dataGridOwner != null)
                {
                    ReflectionHelper.Execute(dataGridOwner, "HandleSelectionForCellInput",
                        this, Mouse.Captured == null && flag, true, false);
                }
                e.Handled = true;
            }
        }
    }
