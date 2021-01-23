    using (SqlConnection Connection = new SqlConnection("..."))
    {
        using (SqlCommand Command = Connection.CreateCommand())
        {
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string Surname = (string) reader["Surname"];
                }
            }
        }
    }
