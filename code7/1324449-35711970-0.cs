    public void Get_Desc()
        {
            string oradb = "Data Source=schema;User Id=user;Password=pwd;";
            string CommandStr = "F_Get_Office_Desc";
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(CommandStr, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("iCode", OracleDbType.Varchar2).Value = Current_code;
                cmd.Parameters.Add("oDesc", OracleDbType.Varchar2, 4).Direction = ParameterDirection.ReturnValue;                
                conn.Open();
                cmd.ExecuteNonQuery();
                Current_Desc.Text = cmd.Parameters["oDesc"].Value.ToString();
            }
        }
