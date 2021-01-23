    using (var ts = new TransactionScope())
    using (var sqlCon = new SqlConnection(conStr))
    {
      sqlCon.Open(); // ensure to open it before SqlBulkCopy can open it in another transactionscope.
      using (var bulk = new SqlBulkCopy(sqlCon))
      {
        // Do you stuff
        bulk.WriteToServer...
      }      
      ts.Complete(); // finish the transaction, ie commit
    }
 
