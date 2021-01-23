     string queries = string.Join(";", queryList.ToArray());
     using(SqlConnection connection = new SqlConnection("Connection String"))
     using(SqlCommand command = new SqlCommand(query, connection))
     {
         connection.Open();
         using(SqlDataReader reader = command.ExecuteReader())
         {
             do
	     {
		if (dr.HasRows)
		{
                    results.Add(query)
                    while (dr.Read())
                    {
                        results.Add(Environment.NewLine + reader.GetString(0));
                    }
		}
		else
                   results.Add(query + Environment.NewLine + "No rows found);
            }
	    while (dr.NextResult());
        }
    }
