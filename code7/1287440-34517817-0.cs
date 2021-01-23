    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDbConnnectionString"].ConnectionString))
    {
        conn.Open();
        using (var cmd = new SqlCommand("SELECT * FROM [Readings] WHERE 1 = 0", conn))
        {
            DataColumn[] dataColumns;
            using (var reader = cmd.ExecuteReader())
                dataColumns = Enumerable.Range(0, reader.FieldCount).
                                         Select(i => new DataColumn(reader.GetName(i), reader.GetFieldType(i))).
                                         ToArray();
            var dataTable = new DataTable("Readings");
            dataTable.Columns.AddRange(dataColumns);
        }
    }
