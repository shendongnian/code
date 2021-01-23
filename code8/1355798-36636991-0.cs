    var context = new BloggingContext();
    var connection = context.Database.GetDbConnection();
    connection.Open();
    using (var command = connection.CreateCommand())
    {
        command.Text= "PRAGMA journal_mode=WAL;";
        command.ExecuteNonQuery();
    }
