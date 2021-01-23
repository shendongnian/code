    private static SQLiteConnection GenData()
    {
        if (!System.IO.File.Exists("MyDatabase.sqlite"))
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        .....
