    string commandText = "select *from Employee where Location=@Location and Age=@Age and Marks=@Marks;"
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@Location", SqlDbType.Char);
        command.Parameters["@Location"].Value = Location;
		
		command.Parameters.Add("@Age", SqlDbType.Int);
        command.Parameters["@Age"].Value = Age;
		command.Parameters.Add("@Marks", SqlDbType.Int);
        command.Parameters["@Marks"].Value = Marks;
		
        
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
