    if (sqlConnection != null)
    {
        sqlConnection.InfoMessage += InfoMessageEventHandler;
    }
    
    private void InfoMessageEventHandler(object sender, SqlInfoMessageEventArgs e)
    {
        // code to save error or warning message 
    }
