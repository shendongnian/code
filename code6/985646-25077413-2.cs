    /* ------------------------------------------------------------------------- */
    public void connectSync()
    {
        connection = new SqlConnection(connectString);
        try
        {
            connection.Open();
            transac = connection.BeginTransaction();
            command = connection.CreateCommand();
            command.Transaction = transac;
            
            if (connection.State == ConnectionState.Open)
                connectResult(true);
            else
                connectResult(false);
        }
        catch
        {
            connectResult(false);
        }
    }
