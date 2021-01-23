    public void SQLDB_UsingReader(string strSQL_WithParam, IDictionary<string, object> obj)
    {
        try
        {
            string where = obj.Any() ? ("where " + string.Join("AND", obj
                                       .Select(x => x.Key +"==@" + x.Key)) : "";
            using (SqlCommand mCmd = new SqlCommand(strSQL_WithParam + where, mConn))
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
