    try
    {
        connection2.Open();
        cmd = connection2.CreateCommand();
        cmd.CommandText = "INSERT INTO frequency(value)VALUES(@message)";
        cmd.Parameters.AddWithValue("@message", message);
        cmd.ExecuteNonQuery();
        connection2.Close();
    }
    catch
    {
       // Do nothing - this should continue to work without being able to make the connection
    } 
