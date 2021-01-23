     connection = new SQLiteConnection(connString);
     connection.SetPassword("12345");
     connection.Open();
     connection.ChangePassword("");
     connection.Close();
