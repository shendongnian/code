    using(var conn = new SQLite.SQLiteConnection(DatabasePath)) 
    {
      conn.Open();
      using(var tr = conn.BeginTransaction())
      {
        try
        {
          using(var cmd = conn.CreateCommand())
          {
            cmd.Transaction = tr;
            cmd.CommandText = @"insert ...";
            cmd.ExecuteNonQuery();
          }
          tr.Commit();
        }
        catch (SQLiteException ex)
        {
          tr.Rollback();
        }
      }
      conn.Close();
    }
