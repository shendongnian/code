    public static int gen_no(string P_PRM_TYPE)
    {
        using (OleDbConnection connection = new OleDbConnection(@"Connection string here"))
        {
            connection.Open();
            int v_last_no = 0;
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = connection;
                string query = @"select PARM_VALUE from soc_parm_mast where PARM_TYPE = @P_PRM_TYPE";
                command.CommandText = query;
                command.Parameters.AddWithValue("@P_PRM_TYPE", P_PRM_TYPE);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!Int32.TryParse(reader["PARM_VALUE"].ToString(), out v_last_no))
                {
                    // Conversion failed, Show message if needed    
                    // v_last_no will be 0
                }
                reader.Close();
            }
            using (OleDbCommand command = new OleDbCommand())
            {
                command.CommandText = @"update soc_parm_mast set PARM_VALUE = PARM_VALUE+1 where PARM_TYPE =@P_PRM_TYPE";
                command.Parameters.AddWithValue("@P_PRM_TYPE", P_PRM_TYPE);
                command.ExecuteNonQuery();
            } 
        }
        return v_last_no;
    }
   
