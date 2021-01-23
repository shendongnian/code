    // Setup table with 5 columns
    DataTable table = new DataTable();
    table.Columns.Add("A", typeof(bool));
    table.Columns.Add("B", typeof(bool));
    table.Columns.Add("C", typeof(bool));
    table.Columns.Add("D", typeof(bool));
    table.Columns.Add("E", typeof(bool));
    
    // Add 20 rows
    for (int i = 0; i < 20; i++ )
        table.Rows.Add(true, true, true, true, true);
    
    // Rows 10 - 15, set column 5 to true
    for (int i = 9; i < 15; i++)
        table.Rows[i].SetField<bool>(4, false);
