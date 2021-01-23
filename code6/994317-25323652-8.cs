    using (SqlConnection connection = new SqlConnection(CloudConfigurationManager.GetSetting("Sql.ConnectionString")))
    {
        conn.Open();
        SqlTransaction transaction = conn.BeginTransaction();
    
        try 
        {  
            foreach (string commandString in dbOperations)
            {
                SqlCommand cmd = new SqlCommand(commandString, conn, transaction);
                cmd.ExecuteNonQuery();
            }
            transaction.Commit(); 
        } // Here the execution is committed to the DB
        catch (Exception)
        {
          transaction.Rollback();
          throw;
        }
        conn.Close();
    }
