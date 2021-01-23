    public void selectMeetings(String PID)
    {
        String connection = "Server=localhost;Database=master;Integrated security=true;";
        using(SqlConnection Connection = new SqlConnection(connection))
        {
          Connection.Open();
    
          Connection.ChangeDatabase(PID);
    
          string script = "CREATE PROCEDURE selectMeetings AS SELECT * FROM dbo.MEETING";
          using(SqlCommand command = new SqlCommand(script, Connection))
          {
            command.ExecuteNonQuery();
          }
        }
    }
