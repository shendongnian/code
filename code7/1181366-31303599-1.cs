    SqlConnection conn = null;
    
    try
    {
        conn = new SqlConnection(...);    
        conn.Open();
        //commands
    }
    catch(Exception ex)
    {
        ...
    }
    finally
    {
        if(conn != null)
            conn.Close();
    }
