    try
    {
        try
        {
            conn = StaticContext.getConnessione();
    
            SqlCommand aCommand = new SqlCommand("SELECT.....", conn);
    
            conn.Open();
            aReader = aCommand.ExecuteReader();
    
    
    
            while (aReader.Read())
            {
                //TODO
            }
    
    
    
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
    }
    
    
    finally
    {
        conn.Close();
    }
