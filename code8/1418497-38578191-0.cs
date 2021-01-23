       var DBConnection = new SQLiteConnection("Data Source=Diary.sqlite;Version=3;");
       string sql = "SHOW TABLES;";
       DBConnection.Open();
       SQLiteCommand command = new SQLiteCommand(sql, DBConnection);
       SQLiteDataReader reader = command.ExecuteReader();
