    public void bw_Convert_DoWork(object sender, DoWorkEventArgs e)
    {           
        e.Result = e.Argument;
        for (int i = 0; i <  fTable.Rows.Count; i++)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_CDR_ANALYZER (LNG_UPLOAD_ID, DAT_START, LNG_DURATION, INT_DIRECTION, INT_CALL_DATA_TYPE, \n" +
                    "TXT_TARGET_NUMBER, TXT_OTHER_PARTY_NUMBER, TXT_TARGET_IMSI, TXT_TARGET_IMEI, TXT_TARGET_CELL_ID, TXT_ROAMING_NETWORK_COMPANY_NAME) VALUES \n" +
                    "(@UPLOAD_ID, @START_DATE, @DURATION, @DIRECTION, @CALL_TYPE, @TARGET_NUMBER, @OTHER_PARTY_NUMBER, @IMSI, @IMEI, @CELL_ID, @ROAMING_NAME)", sqlCon);
                cmd.Parameters.Add("@UPLOAD_ID", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@START_DATE", SqlDbType.DateTime).Value = fTable.Rows[i]["CallDate"];
                cmd.Parameters.Add("@DURATION", SqlDbType.Int).Value = fTable.Rows[i]["CallDuration"];
                cmd.Parameters.Add("@DIRECTION", SqlDbType.Int).Value = GetCallDirection(fTable.Rows[i]["CallDirection"].ToString());
                cmd.Parameters.Add("@CALL_TYPE", SqlDbType.Int).Value = GetCallType(fTable.Rows[i]["CallType"].ToString());
                cmd.Parameters.Add("@TARGET_NUMBER", SqlDbType.VarChar, 25).Value = fTable.Rows[i]["TargetNo"];
                cmd.Parameters.Add("@OTHER_PARTY_NUMBER", SqlDbType.VarChar, 25).Value = fTable.Rows[i]["OtherPartyNo"];
                cmd.Parameters.Add("@IMSI", SqlDbType.VarChar, 50).Value = fTable.Rows[i]["IMSI"];
                cmd.Parameters.Add("@IMEI", SqlDbType.VarChar, 50).Value = fTable.Rows[i]["IMEI"];
                cmd.Parameters.Add("@CELL_ID", SqlDbType.VarChar, 50).Value = fTable.Rows[i]["CellID"];
                cmd.Parameters.Add("@ROAMING_NAME", SqlDbType.NVarChar, 255).Value = fTable.Rows[i]["RoamingCompany"];
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                sqlCon.Close();
            }
            bw_Convert.ReportProgress((100 * i) / fTable.Rows.Count);  
          Label1.Invoke((MethodInvoker)delegate {
            Label1.Text = i.ToString() + "Files Converted";});                 
        }    
    }
