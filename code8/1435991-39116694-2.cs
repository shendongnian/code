            var tran = new CommittableTransaction();
            using (var conn = new SqlConnection(connString))
            {
             conn.Open();
            try
            {
               conn.EnlistTransaction(tran);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                // Loop the Insert operation here 
                cmd.CommandText = "INSERT Operation";
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
