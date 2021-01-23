    private void Query(string sqlCommand, Action<SqlDataReader, List<string> loader)
    {
        using (dbCon = new SqlConnection(connectionString))
        using (dbcmd = dbCon.CreateCommand())
        {
            dbcmd.CommandText = sqlCommand;
            dbCon.Open();
            DataTable dt = reader.GetSchemaTable();
            List<string> columns = dt.AsEnumerable().Select(x => x.Field<string>("COLUMNNAME")).ToList();
            using (reader = dbcmd.ExecuteReader())
            {
                while (reader.Read())
                  if(loader != null) 
                    loader(reader, columns);
            }
        }
    }
