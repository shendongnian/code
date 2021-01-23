    // Open connection
    SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), sqlpath);
    try {
       // Start transaction
       conn.BeginTransaction();
       try {
          // Execute commands...
          // Commit transaction
          conn.Commit();
       }
       catch (Exception) {
          // Rollback transaction
          conn.Rollback();
       }
    }
    finally {
       // Close connection
       conn.Close();
    }
