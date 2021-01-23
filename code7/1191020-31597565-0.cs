    using(var reader = Command.ExecuteReader())
    {
       while(reader.Read())
       {
           string name = reader.GetString(0); // Hulk
           string surname = reader.GetString(1); // Hogan
       }
    }
