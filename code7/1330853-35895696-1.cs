    void Main()
    {
      var vfpCode = @"
      local lnHandle
      lnHandle = SQLStringConnect('driver={SQL Server Native Client 11.0};'+;
          'server=.;Trusted_Connection=yes;database=001-CARL_V4')
      SQLExec( m.lnHandle, ;
       'select  title as [title], firstName as [fname], lastName as [sname] from CARL_Owners', ;
       'crsOwners')
      SQLDisconnect(0)
      
      
      * if you can use exclusive locks then:
      * zap    
      * assuming you cant
      
      delete from Client
      insert into Client (Title,Fname,Sname) ;
          select Title,Fname,Sname from crsOwners";
          
          
      using (var importConnection = new OleDbConnection(connectionString:
          @"Provider=vfpoledb.1;" +
          @"data source=C:\Users\Joshua.cameron\Desktop\PCHomesImportTestBlank\PCHomesServer\DATABASE\pchomes.dbc"))
      {
        OleDbCommand cmd = new OleDbCommand("ExecScript", importConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("code", vfpCode);
    
        importConnection.Open();
        cmd.ExecuteNonQuery();
        importConnection.Close();
      }
    }
