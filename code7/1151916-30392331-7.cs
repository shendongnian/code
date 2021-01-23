    List<string> Result = new List<string>();
    string Command = "SELECT [UserName] FROM [aspnet_Users];";
    using (SqlConnection mConnection = new SqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (SqlCommand cmd = new SqlCommand(Command, mConnection))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Result.Add((string)reader[0]);
                }
            }
        }
    }
