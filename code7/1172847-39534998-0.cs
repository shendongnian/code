                ServerConnection connection = new ServerConnection(ServerName);
                Server sqlServer = new Server(connection);
                Database QADatabase = sqlServer.Databases[DatabaseName];
                QADatabase.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                QADatabase.Alter(TerminationClause.RollbackTransactionsImmediately);
                QADatabase.Refresh();
    //DACPAC logic goes here
                QADatabase.DatabaseOptions.UserAccess = DatabaseUserAccess.Multiple;
                QADatabase.Alter(TerminationClause.RollbackTransactionsImmediately);
                QADatabase.Refresh();
