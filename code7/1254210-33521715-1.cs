    public int UpdateThisTable(int TableUID, string SomeField)
    {
           
            string StoredProcedure = "usp_SomeStoredProcedure";
            SqlConnection conn = new SqlConnection(enteryourconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableUID", TableUID);
            cmd.Parameters.AddWithValue("@SomeField", SomeField);
            conn.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsaffected;
    }
