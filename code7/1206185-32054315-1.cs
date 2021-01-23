    using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Connection"]))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Core.up_ExternalTradeInsert", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RowCount", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add(new SqlParameter("@ExecID", execID));
        cmd.Parameters.Add(new SqlParameter("@SecondaryExecID", secondaryExecID));
        cmd.Parameters.Add(new SqlParameter("@SecurityID", securityID));
        cmd.Parameters.Add(new SqlParameter("@SecurityIDSource", securityIDSource));
        cmd.Parameters.Add(new SqlParameter("@LastQty", lastQty));
        cmd.Parameters.Add(new SqlParameter("@LastPx", lastPx));
        cmd.Parameters.Add(new SqlParameter("@TransactTime", transactTime));
        cmd.Parameters.Add(new SqlParameter("@Side", side));
        cmd.Parameters.Add(new SqlParameter("@OrderID", orderID));
        cmd.Parameters.Add(new SqlParameter("@ClOrdID", clOrdID));
        cmd.Parameters.Add(new SqlParameter("@Account", account));
        cmd.Parameters.Add(new SqlParameter("@SenderId", senderId));
    
        cmd.ExecuteNonQuery();//.ExecuteNonQuery();
        int RowsAffected = Convert.ToInt32(cmd.Parameters["@RowCount"].Value);
    }
