    string myCommand = @"Use ('P:\Test\DSPC-1') alias myData
    Set Index To ('P:\Test\DSPC-1_Custom.NDX')
    select * from myData ;
      where dp_file = '860003' ;
      into cursor crsResult ;
      nofilter
    SetResultset('crsResult')";
    
    DataTable resultTable = new DataTable();
    using (oleDbConnection = new OleDbConnection(@"Provider=VFPOLEDB;Data Source=P:\Test"))
    {
      oleDbConnection.Open();
      OleDbCommand command = new OleDbCommand("ExecScript", oleDbConnection);
      command.CommandType = CommandType.StoredProcedure;
      command.Parameters.AddWithValue("code", myCommand);
    
      resultTable.Load(cmd.ExecuteReader());
      oleDbConnection.Close();
    }
