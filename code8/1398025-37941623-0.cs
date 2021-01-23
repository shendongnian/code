    public bool isConnected()
    {
         if (dbConn != null && dbConn.State == ConnectionState.Open)
         {
             return true;
         }
         else
         {
             return false;
         }
    }
