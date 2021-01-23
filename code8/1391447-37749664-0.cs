    System.Data.SqlClient.SqlConnection sqlConn;
    System.Data.SqlClient.SqlCommand sqlComm;
    ConnectionManager cm = Dts.Connections["MY_NEW_CM"];
    
    // Request an open connection
    sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
    
    // Do your work
    sqlComm = new System.Data.SqlClient.SqlCommand("UPDATE YourTable SET YourColumn = 'SomeValue'", sqlConn);
    int rowsAffected = sqlComm.ExecuteNonQuery();
