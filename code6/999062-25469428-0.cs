    public static bool doesUserHaveRole(string username, string roleToTest)
    {
        string sqlStatement = "SELECT COUNT(*) AS C FROM UsersTb WHERE LoginName=@LoginName AND UserRole=@UserRole";
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OleDbConnection oleDbConn = new OleDbConnection(connStr);
        oleDbConn.Open();
        OleDbCommand command = new OleDbCommand(sqlStatement, oleDbConn);
        command.Parameters.AddWithValue("@LoginName", username);
        command.Parameters.AddWithValue("@UserRole", roleToTest);
        OleDbDataReader dr = command.ExecuteReader();
        return dr.HasRows && ((int) dr["C"]) > 0;
     }
