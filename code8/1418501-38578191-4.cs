    using(var connection = new SQLiteConnection("Data Source=Diary.sqlite;Version=3;"))
    {
       connection.Open();
       var command = new SQLiteCommand(sql, DBConnection);
       var reader = command.ExecuteReader();
       //do stuff
    }
