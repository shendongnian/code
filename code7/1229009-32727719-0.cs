    using (var connection = new SQLiteConnection(path)) 
    {
        connection.CreateTable<MovieID>();
        connection.Insert(new MovieID { ID = "someId" });
        var movies = connection.Table<MovieID>().ToList();
    }
