    SqlConnection connection;
    SqlCommand command;
    try 
    {
        // Properly fill in all constructor variables.
        connection = new SqlConnection();
        command = new SqlCommand();
        connection.Open();
        command.ExecuteNonQuery();
        // Parse the results
    }
    catch (Exception ex)
    {
        // Do whatever you need with exception
    }
    finally
    {
        connection.Dispose();
        command.Dispose()
    }
