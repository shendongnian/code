    command = connection.CreateCommand();
    command.CommandText = @"
      SELECT *
      FROM Users
      WHERE phone = @UName
        AND password = HASHBYTES('SHA1', @PWord)";
    //Add parameters like that and it will pass in correct data type
    command.Parameters.Add("@UName", SqlDbType.VarChar, 50).Value = username;
    command.Parameters.Add("@PWord", SqlDbType.VarChar, 50).Value = password;
    //command.Parameters.AddWithValue("@UName", username);
    //command.Parameters.AddWithValue("@PWord", password);
    
    reader = command.ExecuteReader();
    
    if (reader.HasRows)
    {
        // ...
    }
