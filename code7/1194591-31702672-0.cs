	public static DataTable GetDataFromSpreadsheet(OleDbConnection conn)
    {
        DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
        conn.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        conn.Close();
        return ds.Tables[0];
    }
