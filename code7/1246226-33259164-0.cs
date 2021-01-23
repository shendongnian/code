    string vfpScript = string.Format(@"
    use UnRepWor shared
    APPEND FROM ('{0}') DELIMITED WITH TAB
    use", @"d:\TestServiceOutput\data.dat");
    
    using (OleDbConnection oledbConn = new OleDbConnection(String.Format(@"Provider=VFPOLEDB.1;Data Source={0};Collating Sequence=MACHINE", Inputpath)))
    {
      OleDbCommand oledbComm = new OleDbCommand { 
        Connection = oledbConn, 
        CommandType = CommandType.StoredProcedure, 
        CommandText="ExecScript" };
      oledbComm.Parameters.AddWithValue("code", vfpScript);
    
      try
      {
        oledbConn.Open();
        oledbComm.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
         throw Utility.GetExceptionDetails(ex,
           "WordRootFoxExportServiceDataAccessLayer - ImportToFoxTable- insert into Fox Table", 
          ex.Message);
      }
    }
