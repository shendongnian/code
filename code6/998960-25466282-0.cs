    SQLiteConnection con = new SQLiteConnection(dbConnection);
    con.Open();
    SQLiteCommand cmd = new SQLiteCommand(con);
    for(int i=0;i < horizontal; i++)
    {
      for(int j=0;j < vertical; j++)
      {
        cmd.CommandText = query;    
        SQLiteDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        // Perform some actions onto DataTable data
      }
    }
    con.Close();
