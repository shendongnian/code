    SqlDataReader reader = cmd.ExecuteReader();
    
    try
    {
        while (reader.Read())
        {
            // Code here
        }
    }
    finally
    {
        if(reader != null)
        {
            reader.Dispose();
        }
    }
