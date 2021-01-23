    using Oracle.DataAccess.Client;
    ...
    public string OraText(string pkey, string[] tables, string[] columns)
    {
        string sSQL = "select " + pkey + "";
        foreach (string s in columns)
        {
            sSQL += ", " + tables[1] + "." + s;
        }
        sSQL += Environment.NewLine + "  from t1 join t2 using (" + pkey + ") "
            + Environment.NewLine + "  where 1=0 ";
        foreach (string s in columns)
        {
            sSQL += " or " + tables[0] + "." + s + " <> " + tables[1] + "." + s;
        }
        return sSQL;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        OracleConnection oc = new OracleConnection(
            "User Id=scott;Password=tiger;Data Source=XE");
        oc.Open();
        string[] tables = {"t1", "t2"};
        string[] columns = {"name", "age"};
            
        string sSQL = OraText("id", tables, columns);
        OracleCommand oracmd = new OracleCommand(sSQL, oc);
        OracleDataReader reader = oracmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetValue(0) + " " 
                + reader.GetValue(1) + " " +reader.GetValue(2));
        }
        oc.Close();
    }
