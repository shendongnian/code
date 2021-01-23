    private void categoryDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (categoryDataGridView.IsCurrentCellDirty)
        {
            categoryDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
