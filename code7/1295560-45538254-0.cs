    public void backup(string strDestination)
    {
          using (var location = new SQLiteConnection(@"Data Source=C:\activeDb.db; Version=3;"))
          using (var destination = new SQLiteConnection(string.Format(@"Data Source={0}:\backupDb.db; Version=3;", strDestination)))
          {
              location.Open();
              destination.Open();
              location.BackupDatabase(destination, "main", "main", -1, null, 0);
          }
    }
