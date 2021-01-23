    using (NpgsqlConnection con=new NpgsqlConnection(@"..."))
    {
      string iCmd = "insert into arrayLog (aVals) values (@aVals)";
      var cmd = new NpgsqlCommand(iCmd,con);
      
      int[,] vals = new int[,] {
        {40,50,90},
        {400,500,900}
      };
      
      cmd.Parameters.AddWithValue("@aVals", vals);
    
      con.Open();
      cmd.Parameters["@aVals"].Value = vals;
      cmd.ExecuteNonQuery();
      con.Close();
    }
