    private DataTable CloneAlteredDataTableSource(DataGridView dgv)
    {
        DataTable dt = dgv.DataSource as DataTable;
    
        if (dt == null)
        {
            return null;
        }
    
        DataTable clone = new DataTable();
    
        foreach (DataColumn col in dt.Columns)
        {
            clone.Columns.Add(col.ColumnName, col.DataType);
        }
    
        string order = string.Empty;
    
        switch (dgv.SortOrder)
        {
            case SortOrder.Ascending: order = "ASC"; break;
            case SortOrder.Descending: order = "DESC"; break;
        }
    
        string sort = dgv.SortedColumn == null ? string.Empty : string.Format("{0} {1}", dgv.SortedColumn.Name, order);
    
        DataRow[] rows = dt.Select(dt.DefaultView.RowFilter, sort);
    
        foreach (DataRow row in rows)
        {
            object[] items = (object[])row.ItemArray.Clone();
            clone.Rows.Add(items);
        }
    
        return clone;
    }
