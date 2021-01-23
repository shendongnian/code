    using (SqlConnection Connection = new SqlConnection("..."))
    {
        using (SqlCommand Command = Connection.CreateCommand())
        {
            Command.CommandText = "SELECT Name, Surname FROM Users WHERE ID='2'";
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string Surname = (string) reader["Surname"];
                }
            }
        }
    }
