    try
    {
        using (var connection = new SqlConnection())
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.ExecuteNonQuery();
            // Do whatever else you need to.
        }
    }
    catch (Exception ex)
    {
        // Handle any exception.
    }
