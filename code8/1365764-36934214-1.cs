    try 
    {
        OleDbConnection c = MakeConnection(Database name);
        OleDbCommand comm = new OleDbCommand();
        comm.CommandText = SqlStr;
        comm.Connection = c;
        comm.ExecuteNonQuery();
        c.Close();
    }
    catch  (Exception e)
    {
        Console.WriteLine(e.Message.ToString());
    }
