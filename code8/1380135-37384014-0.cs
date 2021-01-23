    private boolean dbQueryLogin(string email, string password)
    {
        string sql = "SELECT pass FROM LoginInfo WHERE email = @email";
        using (var connection = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand(sql))
            {
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                using (var reader = command.ExecuteReader())
                {
                    // FIXME: What do you want to do if
                    // there are no matches?
                    reader.Read();
                    return reader.GetString(0) == password;
                }
            }
        }
    }
