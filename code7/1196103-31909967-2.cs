    // assumes the columns in the DataGridView are named as follows:
    var columns = new[] {"Id", "Invoice_Id", "Software_Id", "Price", "Quantity", "Sum" }
    var dt = new DataTable();
    foreach (DataGridViewColumn column in dgv.Columns)
    {
        // note: this is case-sensitive
        if (columns.Contains(column.Name))
        {
            dt.Columns.Add();
        }
    }
