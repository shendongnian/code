    public DataSet ExecProc(string procName)
     {
         string SqlDBConnection = Utils.GetConnectionString();
         DataSet ds = new DataSet();
         SqlConnection sqlConn = new SqlConnection(SqlDBConnection);
         SqlCommand sqlCmd = new SqlCommand(procName, sqlConn);
         sqlCmd.CommandType = CommandType.StoredProcedure;
         sqlConn.Open();
         DataTable dt = new DataTable();
         dt.Load(sqlCmd.ExecuteReader());
         ds.Tables.Add(dt);
         sqlConn.Close();
         return ds;
     }
