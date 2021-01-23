    using (var con = new SQLiteConnection { ConnectionString = "connectionstring" })
    {
         using(var cmd = new SQLiteCommand { Connection = con })
         {
             // check state connection if open then close, else close proceed
             if(con.State == ConnectionState.Open)
               con.Close();
             //then
             try
             {
                // try connection to Open
                con.Open();
             }
             catch
             {
                //catch if found error, message : 'Invalid Connection string'
             }
             ........ // insert query here
             
         } // Close Command
    
    }  // Close Connection
