    string sqlConn = "Data Source=YOURSERVERNAME;Initial Catalog=DBNAME;User ID=DBUSER;Password=DBUSERPWS;Application Name=MyTestApp;"
    //For port number
    //string sqlConn = "Data Source=YOURSERVERNAME,5432;Initial Catalog=DBNAME;User ID=DBUSER;Password=DBUSERPWS;Application Name=MyTestApp;"
    
    SqlConnection myConnection = new SqlConnection(sqlConn);
    									   
    try
    {
        myConnection.Open();
    	MessageBox.Show("Connected successfully");	            
    
    }
    catch(Exception e)
    {
    	            
    	MessageBox.Show("Error. Error Message:" + ex.Message);
        
    }
