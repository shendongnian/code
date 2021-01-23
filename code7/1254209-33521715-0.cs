    public int UpdateThisTable(int TableUID, string SomeField)
    {
            DataSet ds = new DataSet();
            string StoredProcedure = "usp_SomeStoredProcedure";
            SqlConnection conn = new SqlConnection(this.o_ConnectionString);
            SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableUID", TableUID);
            cmd.Parameters.AddWithValue("@SomeField", SomeField);
            conn.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsaffected;
    }
