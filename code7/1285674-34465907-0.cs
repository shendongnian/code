    private void dgvtest1_CellEndEdit(Object sender, DataGridViewCellEventArgs e)
    {
        if(e.RowIndex < 0)
            return;
        if(e.ColumnIndex < 0)
            return;
        DataGridView dgv = (DataGridView)sender;
        DataGridViewRow row = dgv.Rows(e.RowIndex);
        Good model = row.DataBoundItem as Good
        if(model == null)
            return;
        //Then decide which property was changed and update it
        String currentColumnName = dgv.Columns(e.ColumnIndex).Name;
        if(currentColumnName.Equals(nameOf(model.SomeProperty)) == true)
        {
            //Update value
            return;
        }
        //.. other columns
    }
