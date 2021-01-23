    // for getting the rowsAffected by each statement individually to generate executionMessage
    static void sqlCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
    {
         SprocController.executionMessage += (e.RecordCount.ToString() + " row(s) affected " +  "\n");
    }
    // for getting the print Messages whenever an informational message occur at connection
    static void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e1)
    {
         SprocController.executionMessage += (e1.Message.ToString() + "\n"); 
    }
