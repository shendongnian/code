    //Let's assume that your values are in a Dictionary
    Dictionary<int, string[]> values = new Dictionary<int, string[]>();
    values.Add(2, new string[] { "A", "D" });
    values.Add(3, new string[] { "A", "C" });
    DataTable table = new DataTable();
    table.Columns.Add("ID");
    foreach (var item in values.Values.SelectMany(EE => EE).Distinct())
         table.Columns.Add(item);
    foreach (var item in values)
    {
        DataRow row = table.NewRow();
         foreach (DataColumn column in table.Columns)
         {
               row[column.ColumnName] = false;
               foreach (var value in item.Value)
                  if (value == column.ColumnName)
                      row[value] = column.ColumnName == value;
                        
         }
         row["ID"] = item.Key;
         table.Rows.Add(row);
    }
