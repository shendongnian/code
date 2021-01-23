    HashSet<DataGridViewRow> _CheckedRows = new HashSet<DataGridViewRow>();
    private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (DataGridView.Columns[e.ColumnIndex].Name.Equals(CheckBoxColumn1.Name) == false)
            return;
        DataGridViewRow row = DataGridView.Rows[e.RowIndex];
        if (Convert.ToBoolean(row.Cells[CheckBoxColumn1.Name].Value) == true)
        {
            _CheckedRows.Add(row);
        }
        else
        {
            _CheckedRows.Remove(row);
        }
    }
