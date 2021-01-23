    String query = "INSERT INTO dbo.CalendarData(Day, Text) VALUES (@eventId, @reminderName)";
    using(SqlConnection connection = new SqlConnection(connectionString))
    using(SqlCommand command = new SqlCommand(query, connection))
    {
        //a shorter syntax to adding parameters
        command.Parameters.AddWithValue("@eventId", 1);
    
        command.Parameters.Add("@reminderName", "abc");
        
        //make sure you open and close(after executing) the connection
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
