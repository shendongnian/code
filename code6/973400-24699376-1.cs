    try
    {
         SqlConnection sqlConn = new SqlConnection("connectionstring");
         sqlConn.Open();
       
    }
    finally
    {
         sqlConn.Close();
    }
