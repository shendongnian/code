    using(SqlConnection connection = new SqlConnection(myConnectionString))
    {
        connection.Open();
        string sql =  "INSERT INTO CalendarData(Day, Text) VALUES(@param1,@param2)";
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.Add("@param1", SqlDbType.Varchar, 50).value = eventId;
            cmd.Parameters.Add("@param2", SqlDbType.Varchar, 50).value = reminderName;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
    
        connection.Close();
    }
