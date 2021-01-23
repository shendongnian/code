        using (var transaction = con.BeginTransaction()) 
        { 
            try
            {
                 for (int q = 0; q < list.Count; q++) 
                 { 
                      ArrayList castarraylist = new ArrayList(); 
                      castarraylist = (ArrayList)(list[q]); 
                      using (var cmd = new SQLiteCommand(con)) 
                      {
                          cmd.Transaction = transaction; 
                          for (int y = 0; y < castarraylist.Count; y++) 
                          { 
                              cmd.CommandText = Convert.ToString(castarraylist[y]); 
                              cmd.ExecuteNonQuery(); 
                          } 
                      }
                 }
                 transaction.Commit(); 
            }
            catch
            {
                 transaction.Rollback();
                 throw;
            }
        }
