    protected void Insert_OnClick(object sender, EventArgs e)
       {
           //begin transaction
           var connection = HoweverYoureManagingConnections();
           using (var transaction = connection.BeginTransaction())//If using OleDb 
           {
 
           try
           {
               var command = new OldDbCommand();
               command.Transaction = transaction;
               //Use passed in command object to issue your queries/inserts/updates in each method.
               Method_A(command);
               Method_B(command);
               Method_C(command);
               transaction.Commit();
           }
           catch(Exception ex)
           {
               //if there was an exception rollback.
               transaction.Rollback();
           }
           }
        }
