    using (SQLiteConnection sqlconn = new SQLiteConnection(ConnectionString))
    {
      sqlconn.Open();
      using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
      {
        cmd.ExecuteNonQuery();
      }
    }
