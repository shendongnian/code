    string conStr = "Data Source:127.0.0.1; Initial Catalog: DatabaseName; uid:username; pwd:password";
    SqlConnection conMsSql = new SqlConnection(conStr);
    MySqlConnection conMySql = new MySqlConnection(conStr);
    
    private void OpenConnection()
    {
        if(conMsSql.state != ConnectionState.Open)
            conMsSql.Open();
        if(conMySql.state != ConnectionState.Open)
            conMySql.Open();
    }
    
