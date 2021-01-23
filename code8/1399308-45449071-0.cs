    public static DataTable ExecuteDataTable(SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {
        DataTable dt = new DataTable();
        // just doing this cause dr.load fails
        dt.Columns.Add("CustomerID");
        dt.Columns.Add("CustomerName");
        SqlDataReader dr = ExecuteReader(conn, cmdType, cmdText, cmdParms);
        // as of now dr.Load throws a big nasty exception saying its not supported. wip.
        // dt.Load(dr);
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
