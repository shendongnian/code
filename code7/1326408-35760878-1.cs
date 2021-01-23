    public static DataSet ExecuteDataSet2(string sql, CommandType cmdType, params OracleParameter[] parameters)
    {
        using (DataSet ds = new DataSet())
        using (OracleConnection connStr = new OracleConnection(ConfigurationManager.ConnectionStrings["DbConn2"].ConnectionString))
        using (OracleCommand cmd = new OracleCommand(sql, connStr))
        {
            cmd.CommandType = cmdType;
            cmd.CommandTimeout = 60 * 22;
            foreach (var item in parameters)
            {
                cmd.Parameters.Add(item);
            }
            try
            {
                cmd.Connection.Open();
                new OracleDataAdapter(cmd).Fill(ds);
            }
            catch (Exception ex)
            {
                utilities.SendErrorEmails(ex);
                throw ex;
            }
            return ds;
        }
    }
