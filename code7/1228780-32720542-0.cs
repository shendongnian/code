    var cnnString = ConfigurationManager.ConnectionStrings["TaktBoardsConnectionString"].ConnectionString;
    using(SqlConnection conn = new SqlConnection(cnnString))
    using(SqlCommand comm = new SqlCommand())
    {
        comm.CommandText = "SELECT * FROM ScheduleDetail WHERE ScheduleID = " + lstShifts.SelectedValue;
        comm.CommandType = CommandType.Text;
        comm.Connection = conn;
    
        conn.Open();
        using(SqlDataReader reader = comm.ExecuteReader())
        {
            while (reader.Read())
            {
                 TimeSpan DBStartTime = (TimeSpan)reader["StartTime"];
                 TimeSpan DBEndTime = (TimeSpan)reader["EndTime"];
                // Add more coding once this works.
            }
        }
    }
