        using (var conn = new SqlConnection(connString))
        {
        conn.Open();
        using (IDbTransaction tran = conn.BeginTransaction())
        {
            try
            {
                // transactional code...
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Loop the Insert operation here 
                    cmd.CommandText = "INSERT Operation";
                    cmd.Transaction = tran as SqlTransaction;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch(Exception ex)
            {
                tran.Rollback();
                throw;
            }
        }
        }
