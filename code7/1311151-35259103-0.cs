    private SqlConnection createConnection
    {
       try
        {
            connect = new SqlConnection(ConnectionStr);
            connect.Open();
        }
        // this is laziness, but it is better than before 
        catch (Exception e)
        {
            // best to log the real error somewhere
            throw;
        }
    }
