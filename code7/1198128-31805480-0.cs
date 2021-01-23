    public int ExecuteNonQuery(SqlParameter[] param, string strSPName)
    {
        using (SqlConnection conn = new SqlConnection(_connStr))
        {
            using (SqlCommand cmd = new SqlCommand(strSPName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
