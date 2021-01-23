    public Dictionary<string, string> GetDropdownItems(string sQuery, string sDTextField, string sDValueField)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        using (OracleConnection odConn = new OracleConnection(sConnStr))
        {
            odConn.Open();
            OracleCommand odCmd = odConn.CreateCommand();
            odCmd.CommandText = sQuery;
            using (var dr = odCmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dict[dr[sDValueField].ToString()] = dr[sDTextField].ToString();
                }
            }
        }
        return dict;
    }
