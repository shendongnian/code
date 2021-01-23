    public DataTable GetInfo()
    {
        DataTable dt = new DataTable();
        cmd.CommandText = "StoreProc_511";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@username", "*****");            
        cmd.Parameters.AddWithValue("@authcode", "*****");
        lock (_dt_sms_result) { 
            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@dt_sms_res", _dt_sms_result);
            tvpParam.SqlDbType = SqlDbType.Structured;
          
            try
            {
                Connect();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                _dt_sms_result.Rows.Clear();
            }
            catch (SqlException se)
            {
                MyLog.Write(new LogPacket(se, DateTime.Now));                
            }
            finally
            {
                Disconnect();
            }
        }
        return dt;
       
    }
