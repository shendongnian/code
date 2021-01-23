    public List<string> getTables()
    {
        List<string> result = new List<string>();
        using (SqlConnection connection = new SqlConnection(appSettings.ConnectionStringSamples))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT name FROM sys.Tables;", connection))
            using (SqlDataReader reader = command.ExecuteReader())
            while (reader.Read()) result.Add(reader["name"].ToString());
        }
        return result;
    }
