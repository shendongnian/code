    public DataTable ToDataTable(DbConnection connection, IQueryable query)
    {
         if (connection == null)
              throw new ArgumentNullException("connection");
         if (query == null)
              throw new ArgumentNullException("query");
         string sqlQuery = query.ToString();
    
         DbCommand cmd = connection.CreateCommand();
         cmd.CommandText = sqlQuery;
         DbDataAdapter adapter = new SqlDataAdapter();
         adapter.SelectCommand = cmd;
         DataTable dt = new DataTable("sd");
    
         try
         {
              cmd.Connection.Open();
              adapter.Fill(dt);
         }
         finally
         {
              cmd.Connection.Close();
         }
         return dt;
    }
