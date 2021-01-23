    using Oracle.DataAccess.Client;
    ...
    OracleConnection oraconn = new OracleConnection(
        "User Id=scott;Password=tiger;Data Source=XE");
    oraconn.Open();
    string sSQL =
        "select id, t2.name, t2.age " +
        "  from t1 join t2 using (id) " +
        "  where t1.name<>t2.name or t1.age<>t2.age";
    OracleCommand oracmd = new OracleCommand(sSQL, oraconn);
    OracleDataReader reader = oracmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader.GetValue(0) + " " 
            + reader.GetValue(1) + " " +reader.GetValue(2));
    }
    oraconn.Close();
    
