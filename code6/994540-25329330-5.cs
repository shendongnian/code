    IDataReader reader = null;
    IConnection dbconn = null;
   
    try
    {
        dbcon = ...
        reader = dbcmd.ExecuteReader();  
        while (reader.Read())
        {
            string roomID = (string)reader["RoomId"];
            string roomName = (string)reader["RoomName"];
            Console.WriteLine("Name: " +
                      roomID + " " + roomName);
        }
        
    }
    catch (InvalidOperationException ex2)
    {
        Console.WriteLine(ex2.Message);
    }
    finally
    {
        // clean up
        if (reader != null)
            reader.Close();
        if (dbcmd != null)
            dbcmd.Dispose();
        // ...
    }
