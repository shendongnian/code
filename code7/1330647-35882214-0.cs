    using (SqlConnection connection = new SqlConnection(connectionString))
	{
	    connection.Open();
	    using (SqlCommand command = new SqlCommand(
		"UPDATE section SET status = @Status WHERE ...", connection))
	    {
                command.Parameters.Add(new SqlParameter("Status", status));
                command.ExecuteNonQuery();
	    }
	}
