     string connectionString = ConfigurationManager.ConnectionStrings["MyConnection].ConnectionString;
     using(FbConnection myConnection = new FbConnection(connectionString))
     {
         // At this point the myConnection instance is certainly closed so
         // it is total useless to check the ConnectionState
         myConnection.Open();
         // At this point the myConnection instance is certainly opened,
         // otherwise you get an exception, also here it is useless 
         // to check the ConnectionState
      
         .... do your stuff with the connection.....
     }
 
 
