    public static int SqlGetInt(string queryString, List<SqlParameter> parms = null)
    {
        int retVal = 0;
        try
        {
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                using (SqlTransaction tr = cn.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, cn))
                    {
                        cmd.Transaction = tr;
                        if(parms != null)
                           cmd.Parameters.AddRange(parms.ToArray());
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                                retVal = GetRdrInt(rdr, 0);
                        }
                    }
                    tr.Commit();
                }
            }
        }
