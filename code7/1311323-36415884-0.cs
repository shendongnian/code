    private void Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        ((DataRowView)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem).BeginEdit();
    }
    
    private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        // need this check for when the program is closed while a cell is in edit mode
        // otherwise an IndexOutOfRangeException occurs
        if (((BindingSource)((DataGridView)sender).DataSource).List.Count > e.RowIndex)
            ((DataRowView)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem).EndEdit();
    }
    
    private void Grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        // commit changes to the table as soon as they are entered so they don't 
        // get overwritten when the DataTable is updated
        if (Grid.IsCurrentCellDirty)
            Grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
