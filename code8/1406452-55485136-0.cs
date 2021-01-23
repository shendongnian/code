    public class MyDataGrid : DataGrid
    {
        private static readonly FieldInfo s_isDraggingSelectionField = 
            typeof(DataGrid).GetField("_isDraggingSelection", BindingFlags.Instance | BindingFlags.NonPublic);
        // DataGrid.OnMouseMove() serves no other purpose than to execute click-drag-selection.
        // Bypass that, and stop 'is dragging selection' mode for DataGrid
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((bool)(s_isDraggingSelectionField?.GetValue(this) ?? false))
                s_isDraggingSelectionField?.SetValue(this, false);
        }
    }
