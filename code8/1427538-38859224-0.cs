    public static bool SaveUser(string Database, string Username, string Password,
    string SecurityLevel)
    {
        bool recordSaved;
        // Transaction for SQL
        OleDbTransaction myTransaction = null;
        try
        {
            // Opens OleDBConnection
            using(OleDbConnection conn = new OleDbConnection(....))
            using(OleDbCommand command = conn.CreateCommand())
            {
                 conn.Open();   
                 using(myTransaction = conn.BeginTransaction())
                 {
                      command.Transaction = myTransaction;
                      string strSQL = @"Insert into tblUserLogin 
                           (UserName, [Password], SecurityLevel) 
                            values (@uname, @pwd, @level)";
                      command.CommandType = CommandType.Text;
                      command.CommandText = strSQL;
                      command.Parameters.Add("@uname", OleDbType.VarWChar).Value = Username;
                      command.Parameters.Add("@pwd", OleDbType.VarWChar).Value = Password;
                      command.Parameters.Add("@level", OleDbType.VarWChar).Value = SecurityLevel;
                      // Executes the Query
                      command.ExecuteNonQuery();
                      myTransaction.Commit();
                 }
            }    
            recordSaved = true;
        } //end try
        catch (Exception ex)
        {
            // I suggest to log somewhere the exception message here....
            myTransaction.Rollback();
            recordSaved = false;
        }
    }
