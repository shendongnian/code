    public void createTables(ExcelWorksheet ws, string TableName)
    {
       ws.Cells[1, 1].Value = "Col1"; //EPPlus generated file will not open properly with this if the cells are all empty
       ws.Tables.Add(ws.Cells[1, 1, 301, 1], TableName);
    }
