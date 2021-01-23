            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var conn = new SqlConnection("your connection string"))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("your SQL here", conn);
                        cmd.ExecuteNonQuery();
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                
            }
            catch (ApplicationException ex)
            {
                
            }
