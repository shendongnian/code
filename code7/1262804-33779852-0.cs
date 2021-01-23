    void Main()
    {
      string result; 
      using (var con = new OleDbConnection(@"..."))
      {
        var cmd = new OleDbCommand("select now()",con);
        con.Open();
        result = (string)cmd.ExecuteScalar();
        con.Close();
      }
      
      DateTime now = DateTime.ParseExact(result, "yyyy-MM-dd HH:mm:ss", null);
      Console.WriteLine(now);
    }
