     string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
     using(FbConnection myConnection = new FbConnection(connectionString))
     {
         // At this point the myConnection instance is certainly closed so
         // it is total useless to check the ConnectionState
         myConnection.Open();
         // At this point the myConnection instance is certainly opened,
         // otherwise you get an exception and your code cannot contine, 
         // so also here it is useless to check the ConnectionState 
         // however...
         if(myConnection.ConnectionState == ConnectionState.Open)
         {
             .... do your stuff with the connection.....
         }
     }
 
 
