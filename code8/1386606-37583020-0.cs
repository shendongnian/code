    public DataSet checkemp(string user)
    {
        strsql = "SELECT * from employee where employeeid = @userid";
        SqlConnection con = GetOpenConnection(connectionString);
        SqlDataAdapter da = new SqlDataAdapter(strsql, connectionString);
        da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar, 50).Value = user;    
        // pretend the user name is "Micheal"
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;
    }
    public static DbConnection GetOpenConnection(string connectionString)
    {
        var cnn = new SqlConnection(connectionString);
        // wrap the connection with a profiling connection that tracks timings 
        return new StackExchange.Profiling.Data.ProfiledDbConnection(cnn, MiniProfiler.Current);
    }
