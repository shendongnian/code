    using(SqlConnection conn = new SqlConnection(myConnString),
          SqlCommand cmd = new SqlCommand("myProc", conn) 
    {
        cmd.CommandType = SqlCommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@param1", 8);
        cmd.Parameters.AddWithValue("@param2", '5.png');
        if (FileSignature == null) //FileSignature  is byte[]
        {
            cmd.Parameters.Add("@FileSignature", SqlDbType.VarBinary, -1);
            cmd.Parameters["@FileSignature"].Value = System.DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@FileSignature", FileSignature); //FileSignature is byte[]
        }
        conn.Open();
        int iReturn = cmd.ExecuteNonQuery();
        conn.Close();
    }
