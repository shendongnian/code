    private DataTable GetDataTableFromDGV(DataGridView dgv)
    {
        // assumes the columns in the DataGridView are named as follows:
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
            // check if the row has a null "Invoice_Id" and exclude
            if(row.Cells["Invoice_Id"] == null
            {
                continue;
            }
          
            DataRow newRow = dt.NewRow();
            foreach (string columnName in columns)
            {
                newRow[columnName] = row.Cells[columnName].Value
            }
            
            dt.Rows.Add(newRow);
        }
        return dt;
    }
