    public static DataGridView RemoveEmptyColumns(this DataGridView gridView)
    {
    	foreach (var column in gridView.EmptyColumns())
    		column.Visible = false;
    	return gridView;
    }
