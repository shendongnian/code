    string Command = "UPDATE tblSignOnOff SET StormOut @StormOut WHERE id = @id";
    using (SqlConnection mConnection = new SqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (SqlCommand myCmd = new SqlCommand(Command, mConnection))
        {
            myCmd.Parameters.AddWithValue("@id", 1902); //TODO set this value dynamicly
            myCmd.Parameters.AddWithValue("@StormOut", storm.StormOut);
            int RowsAffected = myCmd.ExecuteNonQuery();
        }
    }
