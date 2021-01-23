    using(SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            using(SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM UserTable WHERE price = @price";
                cmd.Parameters.Add(new SqlParameter("@price", 10000));
                int count = int.Parse(command.ExecuteScalar());         
            }
        }
        catch (Exception ex)
        {
            //Handle your exception;   
        }
    } 
