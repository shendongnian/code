    static DataTable exec_DT(string query, string conn_str)
    {
        DataTable retVal = new DataTable();
        using (DbConnection conn = MyDbProvider.CreateConnection())
        {
            conn.ConnectionString = conn_str;
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                conn.Open();
                using (DbDataReader rdr = cmd.ExecuteReader())
                {
                    retVal.Load(rdr);
                    rdr.Close();
                }
            }
        }
        return retVal;
    }
