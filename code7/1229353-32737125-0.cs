    using (SqlCommand sqlCatCmd = new SqlCommand())
    {
       sqlCatCmd.CommandText = 
           "INSERT INTO [ChargeType](IsRecurring, IsApplied4NewMembers, Name, PurseID, AllowFamilyDiscount) OUTPUT Inserted.ID " +
           "Values (@IsRec, @NewMem, @CName, @PurseID, @FamDisc)";
    
      //Connections are opened further up the code no need to include
      sqlCatCmd.Connection = _importSettings.sqlServerConnection;
      sqlCatCmd.Transaction = _importSettings.sqlServerTransaction;
    
      //Parameters
      sqlCatCmd.Parameters.AddWithValue("@IsRec", _reapply);
      sqlCatCmd.Parameters.AddWithValue("@NewMem", _onNewMem);
      sqlCatCmd.Parameters.AddWithValue("@CName", _name);
      sqlCatCmd.Parameters.AddWithValue("@PurseID", _purse);
      sqlCatCmd.Parameters.AddWithValue("@FamDisc", _applyFamDisc);
    
      //ExecuteScalar to get OUTPUT value from Sql string
      int insertedId = sqlCatCmd.ExecuteScalar() as int;
    
     //update variable with returned id value
     _chrgTypeReturnedId = insertedId;
     _importSettings.sqlServerTransaction.Commit();
     conn.CloseSqlConnection(_importSettings.sqlServerConnection);
    }
