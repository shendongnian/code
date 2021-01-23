    private DataTable GetDataTableFromDGV(DataGridView dgv)
    {
        // use your actual columns names instead of Col1, Col2, etc...
        var columns = new[] {"Invoice_Id", "Software_Id", "Price", "Quantity", "Sum" }
        var dt = new DataTable();
        foreach (DataGridViewColumn column in dgv.Columns)
        {
            if (columns.Contains(column.Name))
            {
                dt.Columns.Add();
            }
        }
        
        foreach (DataGridViewRow row in dgv.Rows)
        {
            DataRow newRow = dt.NewRow();
            foreach (string columnName in columns)
            {
                newRow[columnName] = row.Cells[columnName].Value
            }
            
            dt.Rows.Add(newRow);
        }
        return dt;
    }
 
