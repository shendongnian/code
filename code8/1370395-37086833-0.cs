     private DataSet GetData(string clientconstr,string actionparam,string userid)
     {
                DataSet dsData = null;
    
                    SqlParameter[] objSqlParam = new SqlParameter[2];
                    objSqlParam[0] = new SqlParameter("@ACTION", SqlDbType.VarChar, 50);
                    objSqlParam[0].Value = actionparam;
                    objSqlParam[1] = new SqlParameter("@USERID", SqlDbType.VarChar, 100);
                    objSqlParam[1].Value = userid;
    
                    dbc = new dbClass(clientconstr);
                    dsData = dbc.ExecuteNonQuery("SPLINV", "SP", objSqlParam);
    }
    
    class dbClass
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataAdapter da = null;
            string connectionstring = "";
    
            public dbClass(string conStr)
            {
                connectionstring = conStr;
            }
    
            public DataSet ExecuteNonQuery(string query, string querytype, SqlParameter[] objArrSqlParamas)
            {
                DataSet ds = null; 
    
                try
                {
                    con = new SqlConnection(connectionstring);
                    con.Open();
    
                    cmd = new SqlCommand();
                    cmd.Connection = con;
    
                    if (querytype.Equals("SP"))
                        cmd.CommandType = CommandType.StoredProcedure;
                    else
                        cmd.CommandType = CommandType.Text;
    
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 300;
    
                    if (objArrSqlParamas != null)
                    {
                        for(int idx=0;idx<objArrSqlParamas.Length;idx++)
                            cmd.Parameters.Add(objArrSqlParamas[idx]);
                    }
    
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd != null)
                        cmd.Dispose();
                    if (da != null)
                        da.Dispose();
                    if (con != null)
                    {
                        con.Dispose();
                        con.Close();
                    }
                }
    
                return ds;
            }
    }
