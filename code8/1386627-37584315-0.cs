    [WebMethod]
        public DataTable GetBankdtls(string pm_Action, string pm_bankid, string pm_name, string pm_Accno, string pm_branch, string pm_VidStr)
        {
            MySqlParameter[] param = new MySqlParameter[6];
            DataTable dt = new DataTable("Bank");
            cn = new MySqlConnection(conn);
            try
            {
                string query = "DML1_getbank_Sp";
                cmd = new MySqlCommand(query, cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                cmd.Parameters.AddWithValue("pm_Action", pm_Action);
                cmd.Parameters.AddWithValue("pm_bankid", pm_bankid);
                cmd.Parameters.AddWithValue("pm_name", pm_name);
                cmd.Parameters.AddWithValue("pm_Accno", pm_Accno);
                cmd.Parameters.AddWithValue("pm_branch", pm_branch);
                cmd.Parameters.AddWithValue("pm_VidStr", pm_VidStr);               
                cn.Open();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cn.Close();
            }
        }
