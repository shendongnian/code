    public static DataGridView RemoveEmptyColumns(this DataGridView grdView)
    {
        for (int i = 0; i < grdView.ColumnCount; i++)
        {
            // On each iteration get all values of a column
            IEnumerable<string> column = grdView.Rows.Cast<DataGridViewRow>().Select(row => (string)row.Cells[i].Value);
            // If there is no value with length > 0 => visible = false
            if (!column.Any(x => x.Length > 0)) { grdView.Columns[i].Visible = false; }
        }
    
        return grdView;
    }
