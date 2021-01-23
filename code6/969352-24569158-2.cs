        using (var transaction = con.BeginTransaction()) 
        { 
            try
            {
                 using (var cmd = new SQLiteCommand(con)) 
                 {
                     cmd.Transaction = transaction; 
                     for (int q = 0; q < list.Count; q++) 
                     { 
                          ArrayList castarraylist = new ArrayList(); 
                          castarraylist = (ArrayList)(list[q]); 
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
