    string delimiter = "\t"; // tab separated
    StringBuilder sb = new StringBuilder();
    // first line column-names
    IEnumerable<string> columnNames = tblExport.Columns.Cast<DataColumn>()
        .Select(column => column.ColumnName);
    sb.AppendLine(string.Join(delimiter, columnNames));
    // second line column-types
    IEnumerable<string> columnTypes = tblExport.Columns.Cast<DataColumn>()
        .Select(column => column.DataType.ToString());
    sb.AppendLine(string.Join(delimiter, columnTypes));
    // rest: table data
    foreach (DataRow row in tblExport.Rows)
    {
        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
        sb.AppendLine(string.Join(delimiter, fields)); 
    }
    string path = @"C:\Temp\Testfile.csv";
    File.WriteAllText(path, sb.ToString());
