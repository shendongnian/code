    List<string> results = new List<string>();
    foreach (string query in queryList)
    {
        using(SqlConnection connection = new SqlConnection("Connection String"))
        using(SqlCommand command = new SqlCommand(query, connection))
        {
             connection.Open();
             using(SqlDataReader reader = command.ExecuteReader())
             {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(query + Environment.NewLine + reader.GetString(0));
                    }
                }
                else
                {
                    results.Add(query + Environment.NewLine + "No rows found";
                }
            }
        }
    }
