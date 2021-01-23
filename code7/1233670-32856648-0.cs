    using (var connection = new OdbcConnection(connectionString))
    {
       var adapter = new OdbcDataAdapter(masterquery, connection);
       connection.Open();
       adapter.Fill(superset);
       superset.Merge(superset);
    }
      
