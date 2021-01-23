    MySql.Data.MySqlClient.MySqlConnection conn;
    string myConnectionString;
    string conn = "Server =<provide proper ip address >;database = db ;uid = username ;password = pwd ;";
    
    conn = new MySql.Data.MySqlClient.MySqlConnection();
    conn.ConnectionString = myConnectionString;
    conn.Open();
