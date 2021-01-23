     using(SqlConnection connection = new SqlConnection(connectionString))
     {
          connection.Open();
          SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
          //Fill the dataSet.
          adapter.Fill(ds);
     }
