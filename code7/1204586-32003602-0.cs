    internal void executeNonQuery(string connectionString, OracleCommand cmd)
    {
        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            using (cmd)
            {
                conn.Open();
                cmd.Connection = conn; // FIX!
                cmd.ExecuteNonQuery(); //here is the error
                conn.Close();
            }
        }
    }
