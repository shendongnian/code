    using(var source = new SQLiteConnection("Data Source=ActiveDb.db; Version=3;"))
    using(var destination = new SQLiteConnection("Data Source=BackupDb.db; Version=3;"))
    {
        source.Open();
        destination.Open();
        source.BackupDatabase(destination, "main", "main", -1, null, 0);
    }
