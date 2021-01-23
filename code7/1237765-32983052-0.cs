    public void SQLDB_UsingReader(string strSQL_WithParam, IDictionary<string, object> obj)
    {
        try
        {
            using (SqlCommand mCmd = new SqlCommand(strSQL_WithParam, mConn))
            {
                foreach pair in obj
                {
                    ... (use pair.Value and pair.Key)
                }
                ...
            }
        }
        ...
    }
