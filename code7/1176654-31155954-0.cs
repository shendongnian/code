    //Making the connection
    string databaseLocation = "location";
    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databaseLocation);
    //Opening the connection
    con.Open();
    //Making a command
    OleDbCommand odc = new OleDbCommand("query",con);
    //Execute a select query
    OleDbDataReader reader = odc.ExecuteReader();
    //Example of retrieving data from select query
    while(reader.Read())
    {
       string result = reader.getString(0);
    }
    //Execute different query (examples: insert into, update, delete)
    odc.ExecuteNonQuery();
    //Closing the connection
    con.Close();
