    OleDbConnection con = new OleDbConnection("my database address");
    OleDbCommand cmd = new OleDbCommand();
    cmd.Connection = con;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "SELECT TOP 1 date FROM myTable";
    con.Open();
    bool exists = true;
    try
    {
      var x = cmd.ExecuteScalar();
    }
    catch (Exception e)
    {
      exists = false;
    }
    con.Close();
