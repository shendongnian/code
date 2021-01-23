    public static void AddToTable()
    { 
        using( DbConnection con = Common.CreateConnection() ) 
        {
          DbCommand cmd = con.CreateCommand();
  
          //cmd.CommandText = SQL COMMAND GOES HERE
          //cmd.ExecuteNonQuery();
        }
    }
