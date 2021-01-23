    var connection = new SQLiteConnection("DataSource=:memory:;Version=3;New=True;");
    connection.Open();
    string sql = "CREATE TABLE  recently_viewed(movieid INTEGER,picture TEXT)";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    using ( command = connection.CreateCommand())
    {
        command.CommandText = "INSERT into recently_viewed(movieid ,picture) values(@movieid,@picture)";
        command.Prepare();
        command.Parameters.AddWithValue("@movieid", id);
        command.Parameters.AddWithValue("@picture", picture);
        command.ExecuteNonQuery();
    }
    
    string   count_table = " SELECT count(*) FROM recently_viewed";
    SQLiteCommand   com3 = new SQLiteCommand(count_table, connection);
    com3.ExecuteNonQuery();
    int   ctable = Convert.ToInt32(com3.ExecuteScalar().ToString());
    Response.Write(ctable);
    connection.Close();
