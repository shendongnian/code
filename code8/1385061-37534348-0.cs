    ...
    try
    {
        SqlConnection connection = new SqlConnection(connString);
        Server server = new Server(new ServerConnection(connection));
        server.ConnectionContext.ExecuteNonQuery(script);
    } catch (ExecutionFailureException ex) {
        MessageBox.Show("Error: " + ex.GetBaseException().Message); 
    }
