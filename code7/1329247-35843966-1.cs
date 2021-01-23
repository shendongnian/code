    private int DeleteProducts(string productIds)
    {
        int recordsDeleted = 0;
         
        using (SqlConnection conn = new SqlConnection("Your connection string here"))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Your SQL Stored Procedure name here", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramProductIds = new SqlParameter("@productIds", varchar(2000));
                    paramProductIds.Value = productIds;
                    cmd.Parameters.Add(paramProductIds);
                    conn.Open();
                    recordsDeleted = cmd.ExecuteNonQuery();
                }
            }
            finally { conn.Close(); }
            
        }
        return recordsDeleted;
    }
