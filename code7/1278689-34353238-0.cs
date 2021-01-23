    public class MyDataGrid : DataGrid
    {
        protected override void OnBeginningEdit(DataGridBeginningEditEventArgs e)
        {
            base.OnBeginningEdit(e);
            this.CommitEdit();
        }
        protected override void OnCellEditEnding(DataGridCellEditEndingEventArgs e)
        {
            base.OnCellEditEnding(e);
            (e.Row.Item as DataRowView).Row[1] = "a string that should be displayed immediatly";
        }
    }
