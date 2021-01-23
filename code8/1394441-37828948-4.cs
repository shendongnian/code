    public static IEnumerable<DataGridViewColumn> EmptyColumns(this DataGridView gridView)
    {
    	return gridView.Columns.Cast<DataGridViewColumn>()
    		.Where(c => gridView.Rows.Cast<DataGridViewRow>().All(r => r.Cells[c.Index].IsEmpty()));
    }
