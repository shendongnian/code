    public override List<Team> Search(Dictionary<string, string> prms, int pageSize, int page) 
    {
        var tresults = new List<Team>();
        using (SqlConnection conn = DB.GetSqlConnection())
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"Search";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (KeyValuePair<string, string> pair in prms)
                    cmd.Parameters.Add(new SqlParameter(pair.Key, System.Data.SqlDbType.VarChar) { Value = pair.Value });
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                // I assume you'll use pageSize and page here?
            }
        }
        
        return tresults; // I assume this is what you want to return.
    }
