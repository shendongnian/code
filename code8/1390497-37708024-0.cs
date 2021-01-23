    var checkedRows = new List<DataGridViewRow>();
    
    dataGridView1.CellClick += (sender, args) =>
    {
        if (args.RowIndex != YOUR_CHECKBOX_COLUMN_INDEX)
        {
            return;
        }
    
        var cell = dataGridView1[args.ColumnIndex, args.RowIndex];
    
        if (cell.Value == null)
        {
            cell.Value = false;
        }
    
        cell.Value = !(bool)cell.Value;
    
        if ((bool)cell.Value)
        {
            checkedRows.Add(dataGridView1.Rows[args.RowIndex]);
        }
        else
        {
            checkedRows.Remove(dataGridView1.Rows[args.RowIndex]);
        }
    };
