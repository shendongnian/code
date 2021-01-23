    using MySql;
    using MySql.Data;
    using MySql.Data.MySqlClient;
    
    private List<string> NumberfromDb = new List<string>();
    private int SingleValue = -1;    
    string QueryGetListUsers = "Select <tablename>.<Columname> From <tablename>;";
    cmd = new MySqlCommand(Query, m_mySqlConnection);
    rdr = cmd.ExecuteReader();
    while (rdr.Read())
    {
     SingleValue = rdr.GetInt32("OK").ToString();
     NumberfromDb.Items.Add(SingleValue);
    }
