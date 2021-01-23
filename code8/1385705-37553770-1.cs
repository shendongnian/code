    public SqlCommand InsertUser(string commandText, string connectionString, User user)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            PropertyInfo[] properties = typeof(user).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if(! String.IsNullOrWhiteSpace(property.GetValue(this).ToString()))
                {
                    command.Parameters.AddWithValue("@" +property.Name ,property.GetValue(this))
                }
            }
            try
            {
                connection.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
