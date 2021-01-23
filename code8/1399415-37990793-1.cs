        using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;
        
                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;
        
                // Open the connection and execute the transaction.
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
      transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
    
                // Assign transaction object for a pending local transaction.
                command.Connection = connection;
                command.Transaction = transaction;
    
                    Method1(command.connection);
                    Method2(command.connection);
        
                }
        }
