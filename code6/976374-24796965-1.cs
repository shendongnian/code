    using (var sqlTran = conn.BeginTransaction()) {
      // Format out SQL to be more readable
      String tblAuto = 
        @"select * 
            from tblAuto_Num 
           where Company_Code = 'Comp' and 
                 Module = 'WSS' and 
                 Sub_Module = 'SVS' and 
                 Doc_Type='ORD'; ";
    
      try {
        using (SqlCommand cmd = new SqlCommand(tblAuto, conn)) {
          cmd.Transaction = sqlTran; // <- Do not forget this
    
          using (SqlDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              ...
            }
          } 
        }
    
        sqlTran.Commit();
      }
      catch (Exception) {
        try {
          sqlTran.Rollback();
          Label1.Text = "bbb";
    
          throw; // <- When catch Exception (base class)  do not forget to throw
        } 
        catch (Exception) {
          // when rollback can't be performed
          throw;
        }
      }
    }
