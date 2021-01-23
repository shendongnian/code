     SqlConnection conn = new SqlConnection(); 
     SqlCommand command1 = new SqlCommand(); 
     SqlCommand command2 = new SqlCommand(); 
    
                SqlTransaction trans = conn.BeginTransaction();
                command1.Transaction = trans;
                command2.Transaction = trans;
    
                try
                {
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (SqlException ex)
                {
                    trans.Rollback();
                }
                finally
                {
                   
                }
     
