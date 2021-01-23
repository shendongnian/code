 C#
private bool isProcessingRow;
private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
{
    if (!isProcessingRow && sender is DataGrid grid)
    {
        isProcessingRow = true;
        switch (e.EditAction)
        {
            case DataGridEditAction.Commit: grid.CommitEdit(DataGridEditingUnit.Row, true); break;
            case DataGridEditAction.Cancel: grid.CancelEdit(DataGridEditingUnit.Row); break;
        }
        isProcessingRow = false;
    }
}
And subscribe this handler to `CellEditEnding` Event.
