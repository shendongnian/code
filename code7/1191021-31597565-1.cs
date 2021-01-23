    string name, surname;
    using(var reader = Command.ExecuteReader())
    {
       while(reader.Read())
       {
           name = reader.GetString(0); // Hulk
           surname = reader.GetString(1); // Hogan
       }
    }
