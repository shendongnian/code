    public static DataTable ExecuteDataTable(SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CustomerID");
        dt.Columns.Add("CustomerName");
        SqlDataReader dr = ExecuteReader(conn, cmdType, cmdText, cmdParms);
        while (dr.Read())
        {
            dt.Rows.Add(dr[0], dr[1]);
        }
        return dt;
    }
    public static DataTable ExecuteDataTableSqlDA(SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {
        System.Data.DataTable dt = new DataTable();
        System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
        da.Fill(dt);
        return dt;
    }
