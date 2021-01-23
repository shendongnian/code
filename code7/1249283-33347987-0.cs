    using (var con = new SqlConnection(Settings.Default.DatabaseString))
    {
        con.Open();
        DataTable tables = con.GetSchema("Tables");
        foreach (DataRow tableRow in tables.Rows)
        {
            String database = tableRow.Field<String>("TABLE_CATALOG");
            String schema = tableRow.Field<String>("TABLE_SCHEMA");
            String tableName = tableRow.Field<String>("TABLE_NAME");
            String tableType = tableRow.Field<String>("TABLE_TYPE");
            DataTable columns = con.GetSchema("Columns", new[] { database, null, tableName });
            foreach (DataRow col in columns.Rows)
            {
                Console.WriteLine(string.Join(",",col.ItemArray));
            }
            DataTable indexes = con.GetSchema("Indexes", new[] { database, null, tableName });
            foreach (DataRow index in indexes.Rows)
            {
                Console.WriteLine(string.Join(",", index.ItemArray));
            }
            DataTable indexColumns = con.GetSchema("IndexColumns", new[] { database, null, tableName });
            foreach (DataRow indexCol in indexColumns.Rows)
            {
                Console.WriteLine(string.Join(",", indexCol.ItemArray));
            }
        }
    }
