    public static UserObject newObject(string ssoTicket, TcpClient tClient)
    {
        string sqlQuery = "SELECT * FROM `users` WHERE `sso_ticket` = '" + ssoTicket + "' LIMIT 1";
        MySqlDataReader mysqlRead = DBManager.database.getCommand( sqlQuery ).ExecuteReader();
        if (mysqlRead.Read()) // read the query and check if we got any data
        {
            return new UserObject(mysqlRead["name"].ToString(), Convert.ToInt32(mysqlRead["rank"]), Convert.ToInt32(mysqlRead["credits"]), tClient);  
        }
        else
        {
           Log.Error("sqlQuery failed : " + sqlQuery );
           return null; //you should check the returned value if its null or not to prevent further problems.
        }                           
    }
