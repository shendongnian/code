    // this also could be a method in MyDbObject
    public DataTable QueryCurrentDB(string SQL)
    {
        DataTable dt = new DataTable();
        using (DB2Connection dbcon = currentDB.GetConnection())
        using (DB2Command cmd = new DB2Command(SQL, dbcon))
        {
            cmd.CommandTimeout = 20;
            dbcon.Open();
            dt.Load(cmd.ExecuteReader());
        }
        return dt;
    }
