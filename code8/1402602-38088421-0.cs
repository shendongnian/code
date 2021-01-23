        try
        {
            using (var scope = new TransactionScope())
            {
                using (var conn = new SqlConnection("your connection string"))
                {
                    conn.Open();
                    // your EF and ADO.NET code
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
