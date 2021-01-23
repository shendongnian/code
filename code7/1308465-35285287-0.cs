    try
    {
         DataSet dsStatusPending = new DataSet();
         StoredProcedure cmdPendingStatus = new StoredProcedure();
         cmdPendingStatus.ProcName = "sp_Name";
         dsStatusPending = DbManager.ExecuteDataSet(cmdPendingStatus);
         if (dsStatusPending.Tables[0].Rows.Count > 0)
         {
              foreach (DataRow rowToInsert in dsStatusPending.Tables[0].Rows)
              {                  
                  if (rowToInsert["ColumnName"] != System.DBNull.Value && rowToInsert["ColumnName"].ToString().ToUpper() == "I")
                  {
                       //User Defined Code Goes Here
                  }
               }
          }
