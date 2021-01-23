    if(new System.Net.NetworkInformation.Ping().Send("Your servername here").Status != 
           System.Net.NetworkInformation.IPStatus.TimedOut)
     {
        // server reachable, try a real SqlServer connection now
        SqlConnection objConnection = new SqlConnection(connectionstring);
       try
       {
           objConnection.Open(); // this line make wait time if connection not available 
           objConnection.Close();
           SqlConnection.ClearAllPools();
          return true; 
       }
       catch
       {
           return false; 
       }
    }
    else 
    {
    	return false; // PING failed
    }
