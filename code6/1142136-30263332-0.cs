    SqlConnection myConnection = new SqlConnection(ConnectionString);
    try
    {
     conn.Open();
     someCall (myConnection);
    }
    finally
    {
     myConnection.Close();                
    }   
