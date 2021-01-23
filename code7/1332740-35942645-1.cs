    public void selectMeetings(String PID)
    {
        String connection = "Server=localhost;Database=master;Integrated security=true;";
        SqlConnection Connection = new SqlConnection();
        Connection = new SqlConnection(connection);
        Connection.Open();
        Connection.ChangeDatabase(PID);
        string script = "CREATE PROCEDURE selectMeetings AS SELECT * FROM dbo.MEETING";
        SqlCommand command = new SqlCommand(script, Connection);
        //You're not fishing. There's no point in catch and release
        command.ExecuteNonQuery();
    }
