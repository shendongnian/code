    var dt = new DataTable();  
    using (var db = dbFactory.Open())
    using (var cmd = db.CreateCommand())
    {
        cmd.CommandText = "select * from [table]";
        cmd.CommandType = CommandType.Text;
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                var row = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (dt.Columns == null || dt.Columns.Count == 0)
                    {
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            dt.Columns.Add(reader.GetName(j), reader.GetFieldType(j));
                        }
                    }
                    var cell = reader.GetValue(i);
                    row[i] = cell;
                }
                dt.Rows.Add(row);
            }
        }
    }
