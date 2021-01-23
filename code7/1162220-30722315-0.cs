        //Get the User ID for the current user. 
        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //conn open before next using
        conn.Open();    
        OracleCommand userCommand = new OracleCommand("Select cust_id from CIS_CUSTOMER_TABLE where cust_username ='" + Session["username"].ToString() + "'", conn);
        OracleDataReader userReader = userCommand.ExecuteReader();
        string User_ID;
