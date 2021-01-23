    var connection = new SqlConnection(@"Your connection string");
    var command = new SqlCommand("dbo.TestProcedure", connection);
    command.CommandType = CommandType.StoredProcedure;
    try
    {
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
            connection.Close();
    }
