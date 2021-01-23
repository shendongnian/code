    private void DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (this.mDataGridView.IsCurrentCellDirty &&
            (this.mDataGridView.CurrentCell.OwningColumn == /* check box column */))
        {
            this.mDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
