    connection.Open(); // Opens connection as SHARED
    try
    {
        // Gain exclusive write-lock by beginning a transaction:
        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "BEGIN IMMEDIATE";
            cmd.ExecuteNonQuery();
        }
    }
    catch(SQLiteException ex)
    {
        if (ex.ResultCode == SQLiteErrorCode.Busy)
        {
            // Connection is still open as read-only (can perform SELECT statements)
        }
        else
            // Unexpected exception:
            throw;
    }
