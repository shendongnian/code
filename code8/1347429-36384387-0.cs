    private List<object> Reader(string sqCommand)
    {
        using (SqlConnection myConnection = new SqlConnection(ConnectionString))
        {
            myConnection.Open();
            using (SqlCommand cmd = new SqlCommand(sqCommand, myConnection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                List<object> list = new List<object>();
                while (reader.Read())
                {
                    list.Add(reader[0]);
                }
                return list;
            }
        }
    }
