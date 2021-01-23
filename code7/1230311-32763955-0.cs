    string connectionString, scriptText;
    SqlConnection sqlConnection = new SqlConnection(connectionString);
    ServerConnection svrConnection = new ServerConnection(sqlConnection);
    Server server = new Server(svrConnection);
    server.ConnectionContext.ExecuteNonQuery(scriptText);
