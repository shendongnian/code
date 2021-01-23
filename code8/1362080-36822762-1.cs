    if(new System.Net.NetworkInformation.Ping().Send("Your servername here").Status != 
           System.Net.NetworkInformation.IPStatus.TimedOut)
     {
        // server reachable, try a real SqlServer connection now
        SqlConnection objConnection = new SqlConnection(connectionstring);
       try
       {
           objConnection.Open(); // this line make wait time if connection not available 
           objConnection.Close();
           // not sure why you would want this
           // only use if you want worse performance
           // SqlConnection.ClearAllPools();
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
