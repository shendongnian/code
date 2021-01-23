    DataTable table = dbCon.ExecuteQuery("my query");
    int rowCount = table.Rows.Count;
    int colCount = table.Columns.Count;
    object[][] objs = new object[colCount][];
    for (int currentColumn = 0; currentColumn < colCount; currentColumn++)
    {
        objs[currentColumn] = new object[rowCount];
        for (int currentRow = 0; currentRow < rowCount; currentRow++)
        {
            objs[currentColumn][currentRow] = table.Rows[currentRow][currentColumn];
        }
    }
