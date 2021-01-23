    public static Int64 GetSynchronizationVersion(string connString)
    {
        Int64 synchronizationVersion = 0;
        string sql =
            "SELECT Convert(BigInt,CHANGE_TRACKING_CURRENT_VERSION());";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            //This query has no parameters.
            try
            {
                conn.Open();
                synchronizationVersion = (Int64)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return synchronizationVersion;
    }
