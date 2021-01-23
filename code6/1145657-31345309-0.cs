     connection = new SQLiteConnection(connString);
     //Set the password
     connection.SetPassword("12345");
     //Open the connection
     connection.Open();
     connection.Close();
