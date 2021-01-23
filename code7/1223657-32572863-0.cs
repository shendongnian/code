    using (NpgsqlConnection connection = new NpgsqlConnection(String.Format(PropertyDataDB.ConnectionStringWithSearchPath, schemaName)))
    {
        connection.Open();
        NpgsqlCommand command = new NpgsqlCommand
        {
            CommandText = commandText,
            Connection = connection
        };
        using (NpgsqlDataReader dataReader = command.ExecuteReader())
        {
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Columns.Contains("auction_time"))
            {
                DataTable clone = dt.Clone();
                clone.Columns["auction_time"].DataType = typeof(TimeSpan);
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = clone.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName == "auction_time" && !row.IsNull(column.Ordinal))
                        {
                            newRow[column.Ordinal] = ((DateTime)row[column.Ordinal]).TimeOfDay;
                        }
                        else
                        {
                            newRow[column.Ordinal] = row[column.Ordinal];
                        }
                    }
                }
                dt = clone;
            }
            BulkCopy(destinationTable, dt);
        }
    }
