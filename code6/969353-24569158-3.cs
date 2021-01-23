    using (var transaction = con.BeginTransaction()) 
    { 
        for (int q = 0; q < list.Count; q++) 
        { 
            var castarraylist = (ArrayList)(list[q]); 
            for (int y = 0; y < castarraylist.Count; y++) 
            { 
                using (var cmd = new SQLiteCommand(con)) 
                {
                    cmd.Transaction = transaction; 
                    cmd.CommandText = Convert.ToString(castarraylist[y]);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        // Log the ex.Message here
                        // ...
                    }
                }
            }
        }
        
        transaction.Commit();
    }
