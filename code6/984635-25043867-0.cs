    DataTable table = new DataTable();
    DataColumn column = new DataColumn();
    column.DataType = System.Type.GetType("System.Int32");
    column.ColumnName = "id";
    table.Columns.Add(column);
    column = new DataColumn();
    column.DataType = Type.GetType("System.String");
    column.ColumnName = "name";
    table.Columns.Add(column);
    foreach (Match m in m1)
    {
        DataRow row = table.NewRow();
        String value=m.Value;
        String[] data=value.split(':');
        row["id"] = data[0];   // For example
        row["name"] = data[1]; 
        table.Rows.Add(row);
    }
