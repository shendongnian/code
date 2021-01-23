    private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //You can check for e.ColumnIndex to limit this to your specific column
        var editingControl = this.categoryDataGridView.EditingControl as DataGridViewComboBoxEditingControl;
        if (editingControl != null)
            editingControl.DroppedDown = true;
    }
