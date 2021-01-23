    public static int Main(string[] args) 
    {
        ExitCode RetVal;
        string accdbConnStr = ConfigurationManager.ConnectionStrings["AccessDBtoSql.Properties.Settings.Company_Master_DataConnectionString"].ToString();
        var con = new OdbcConnection(accdbConnStr);
        try
        { 
            con.Open();
            con.Close();
        }
        ...
        return (int)RetVal;
