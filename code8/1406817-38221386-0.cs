    var tableJoined = table1.Clone(); // create columns from table1
    // add columns from table2 except id
    foreach (DataColumn column in table2.Columns)
    {
        if (column.ColumnName != id)
            tableJoined.Columns.Add(column.ColumnName, column.DataType);
    }
    tableJoined.BeginLoadData();
    foreach (DataRow row1 in table1.Rows)
    {
        foreach (DataRow row2 in table2.Rows)
        {
            if (row1.Field<string>(id) == row2.Field<string>(id))
            {
                var list = row1.ItemArray.ToList(); // items from table1
                // add items from table2 except id
                foreach (DataColumn column in table2.Columns)
                    if (column.ColumnName != id)
                        list.Add(row2[column]);
                tableJoined.Rows.Add(list.ToArray());
            }
        }
    }
    tableJoined.EndLoadData();
