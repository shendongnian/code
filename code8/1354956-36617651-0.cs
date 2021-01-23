    string conn = @"Data Source=database.s3db;Password=Mypass;";
    SQLiteConnection connection= new SQLiteConnection(conn);
    connection.Open();
    //Some code
    connection.ChangePassword("Mypass");
    connection.Close();
