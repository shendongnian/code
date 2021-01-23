    string oradb = "Data Source=ORCL;User Id=hr;Password=hr;";
    OracleConnection conn = new OracleConnection(oradb);  // C#
    conn.Open(); 
    OracleCommand cmd = new OracleCommand();
    cmd.Connection = conn;
    cmd.CommandText = "select * from some table";
    cmd.CommandType = CommandType.Text; 
    OracleDataReader dr = cmd.ExecuteReader();
    dr.Read();
    string text = dr.GetString(0);
    conn.Dispose();
