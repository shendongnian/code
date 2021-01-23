    uint rows = (uint)table.Rows.Count; 
    uint columns = (uint)table.Columns.Count;
    var data = new object[rows, columns];
    int i = 0;
    foreach (System.Data.DataRowView drv in table.DefaultView)
    {
        for( int x = 0; x<columns; x++)
    {
        System.Data.DataRow ViewRow = drv.Row;
        data[i, x] = drv[x];
        i++;
    }
    }
