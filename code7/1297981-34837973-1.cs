    using (SqlConnection conn = new SqlConnection(connStr))
    {
       try 
       {
          conn.Open();
          // all your logic here (SELECT, INSERT etc.)
       }
       catch (Exception exc)
       {
          // exception handling here
       }
       finally
       {
          if (conn.State == ConnectionState.Closed)
           conn.Close();
       }
    }
