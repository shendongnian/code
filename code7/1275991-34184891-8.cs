    public static System.Data.DataSet FetchAll(Table fromTable)
    {
        var ret = new System.Data.DataSet();
        using (var conn = new System.Data.SqlClient.SqlConnection(_connectionString))
        {
            string tableName = "";
            if (!_tableNames.TryGetValue(fromTable, out tableName)) throw new ArgumentException(string.Format(@"The table value ""{0}"" is not known.", fromTable.ToString()));
            string query = string.Format("SELECT * FROM {0}", tableName);
            using (var command = new System.Data.SqlClient.SqlCommand(query, conn))
            {
                using (var adapter = new System.Data.SqlClient.SqlDataAdapter(command))
                {
                    adapter.Fill(ret);
                }
            }
        }
        return ret;
    }
